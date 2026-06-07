// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
using System.Globalization;
using System.Text.Json;
using Zu.Chrome.DriverCore;
using Zu.ChromeDevTools;
using Zu.ChromeDevTools.Runtime;
using Zu.Chrome;
using Zu.WebDriver.AsyncInteractions;
using Zu.WebDriver;
using Zu.WebDriver.BasicTypes;

namespace Zu.ChromeWebDriver
{
    public class ChromeDriverTargetLocator : ITargetLocator
    {
        private ZuChromeDriver _ZuChromeDriver;
        public ChromeDriverTargetLocator(ZuChromeDriver ZuChromeDriver)
        {
            _ZuChromeDriver = ZuChromeDriver;
        }

        public Task<string> GetWindowHandle(CancellationToken cancellationToken)
        {
            var id = _ZuChromeDriver.DevTools?.ConnectedTargetId;
            if (string.IsNullOrEmpty(id))
                throw new WebDriverException("No window handle is available for the current target.");
            return Task.FromResult(id);
        }

        public async Task<List<string>> GetWindowHandles(CancellationToken cancellationToken)
        {
            var sessions = await _ZuChromeDriver.DevTools.GetSessions(_ZuChromeDriver.Port).ConfigureAwait(false);
            return sessions?.Where(s => string.Equals(s.Type, "page", StringComparison.OrdinalIgnoreCase)).Select(s => s.Id).ToList()
                   ?? new List<string>();
        }

        public Task<string> SwitchToActiveElement(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IAlert> SwitchToAlert(CancellationToken cancellationToken = default)
        {
            if (_ZuChromeDriver.FrameTracker?.TryGetBlockingJavaScriptDialog(out _) != true)
            {
                throw new NoAlertPresentException();
            }

            return Task.FromResult(_ZuChromeDriver.Alert);
        }

        public Task SwitchToDefaultContent(CancellationToken cancellationToken = default)
        {
            _ZuChromeDriver.Session?.SwitchToTopFrame();
            return Task.CompletedTask;
        }

        private static async Task EnsureFrameExecutionContextAsync(FrameTracker tracker, string frameId, CancellationToken cancellationToken)
        {
            if (tracker == null || string.IsNullOrEmpty(frameId))
                return;
            for (var attempt = 0; attempt < 100; attempt++)
            {
                if (tracker.GetContextIdForFrame(frameId) != null)
                    return;
                await Task.Delay(50, cancellationToken).ConfigureAwait(false);
            }

            throw new WebBrowserException("No execution context is available for this frame yet.", "unsupported operation");
        }

        /// <summary>
        /// Map CDP / WebBrowser failures to WebDriver-style <see cref="NoSuchFrameException"/> where appropriate.
        /// </summary>
        private static Exception MapFrameSwitchException(Exception ex)
        {
            if (ex is NoSuchFrameException)
                return ex;
            if (ex is WebBrowserException wbe)
            {
                if (!string.IsNullOrEmpty(wbe.Error) && wbe.Error.Equals("NoSuchFrameException", StringComparison.OrdinalIgnoreCase))
                    return new NoSuchFrameException(wbe.Message, wbe);
                return wbe;
            }

            if (ex is CommandResponseException cdp)
                return new NoSuchFrameException(cdp.Message, cdp);
            return new NoSuchFrameException(ex.Message, ex);
        }

        private static void RethrowFrameSwitch(Exception ex)
        {
            throw MapFrameSwitchException(ex);
        }

        private static async Task<string> GetFrameIdForSwitchAsync(
            ZuChromeDriver driver,
            string evaluateFrameId,
            string script,
            string argsJson,
            CancellationToken cancellationToken)
        {
            for (var attempt = 0; attempt < 80; attempt++)
            {
                try
                {
                    var frame = await driver.WebView.GetFrameByFunction(evaluateFrameId, script, argsJson, cancellationToken).ConfigureAwait(false);
                    if (!string.IsNullOrEmpty(frame))
                        return frame;
                }
                catch (WebBrowserException wbe) when (
                    string.Equals(wbe.Error, "NoSuchFrameException", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(wbe.Message, "no such frame", StringComparison.OrdinalIgnoreCase))
                {
                }

                await Task.Delay(50, cancellationToken).ConfigureAwait(false);
            }

            return null;
        }

        private async Task FinishFrameSwitchAsync(string frameId, CancellationToken cancellationToken)
        {
            await EnsureFrameExecutionContextAsync(_ZuChromeDriver.FrameTracker, frameId, cancellationToken).ConfigureAwait(false);
            await _ZuChromeDriver.WebView.WaitForFrameDocumentReadyAsync(frameId, TimeSpan.FromSeconds(30), cancellationToken).ConfigureAwait(false);
            await EnsureFrameExecutionContextAsync(_ZuChromeDriver.FrameTracker, frameId, cancellationToken).ConfigureAwait(false);
        }

        public async Task SwitchToFrame(int frameIndex, CancellationToken cancellationToken = default)
        {
            if (frameIndex < 0)
                throw new NoSuchFrameException("no such frame");

            var script = "function(idx) { var frames = document.querySelectorAll('iframe, frame'); return frames[idx] || null; }";
            var argsJson = $"[{frameIndex.ToString(CultureInfo.InvariantCulture)}]";
            try
            {
                var frame = await GetFrameIdForSwitchAsync(_ZuChromeDriver, _ZuChromeDriver.Session.GetCurrentFrameId(), script, argsJson, cancellationToken).ConfigureAwait(false);
                if (string.IsNullOrEmpty(frame))
                    throw new NoSuchFrameException("no such frame");
                var res = await _ZuChromeDriver.WebView.CallFunction(script, argsJson, _ZuChromeDriver.Session.GetCurrentFrameId(), true, false, cancellationToken).ConfigureAwait(false);
                var elementId = ResultValueConverter.ToElementId(res?.Result?.Value, _ZuChromeDriver.Session.GetElementKey());
                var chromeDriverId = Util.GenerateId();
                var kSetFrameIdentifier = "function(frame, id) {" + "  frame.setAttribute('cd_frame_id_', id);" + "}";
                var setArgs = $"{_ZuChromeDriver.Session.GetElementJsonString(elementId)}, \"{chromeDriverId}\"";
                var res2 = await _ZuChromeDriver.WebView.CallFunction(kSetFrameIdentifier, setArgs, _ZuChromeDriver.Session.GetCurrentFrameId(), true, false, cancellationToken).ConfigureAwait(false);
                _ZuChromeDriver.Session.SwitchToSubFrame(frame, chromeDriverId);
                await FinishFrameSwitchAsync(frame, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                RethrowFrameSwitch(ex);
            }
        }

        public async Task SwitchToFrame(string frameName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(frameName))
                throw new WebBrowserException("frame identifier must not be empty", "NoSuchFrameException");

            var script = "function(name) {" + " name = String(name);" + " var frames = document.querySelectorAll('iframe, frame');" + " for (var i = 0; i < frames.length; i++) {" + " var f = frames[i];" + " if (f.name === name || f.id === name) return f;" + " }" + " return null;" + "}";
            var argsJson = JsonSerializer.Serialize(new[]{frameName}, ChromeDevToolsJsonSerializerOptions.Instance);
            try
            {
                var frame = await GetFrameIdForSwitchAsync(_ZuChromeDriver, _ZuChromeDriver.Session.GetCurrentFrameId(), script, argsJson, cancellationToken).ConfigureAwait(false);
                if (string.IsNullOrEmpty(frame))
                    throw new NoSuchFrameException("no such frame");
                var res = await _ZuChromeDriver.WebView.CallFunction(script, argsJson, _ZuChromeDriver.Session.GetCurrentFrameId(), true, false, cancellationToken).ConfigureAwait(false);
                var elementId = ResultValueConverter.ToElementId(res?.Result?.Value, _ZuChromeDriver.Session.GetElementKey());
                var chromeDriverId = Util.GenerateId();
                var kSetFrameIdentifier = "function(frame, id) {" + "  frame.setAttribute('cd_frame_id_', id);" + "}";
                var setArgs = $"{_ZuChromeDriver.Session.GetElementJsonString(elementId)}, \"{chromeDriverId}\"";
                var res2 = await _ZuChromeDriver.WebView.CallFunction(kSetFrameIdentifier, setArgs, _ZuChromeDriver.Session.GetCurrentFrameId(), true, false, cancellationToken).ConfigureAwait(false);
                _ZuChromeDriver.Session.SwitchToSubFrame(frame, chromeDriverId);
                await FinishFrameSwitchAsync(frame, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                RethrowFrameSwitch(ex);
            }
        }

        public async Task SwitchToFrameByElement(string elementId, CancellationToken cancellationToken = default)
        {
            var tagName = await _ZuChromeDriver.ElementUtils.GetElementTagName(elementId, cancellationToken).ConfigureAwait(false);
            if (string.IsNullOrEmpty(tagName)
                || (!tagName.Equals("frame", StringComparison.OrdinalIgnoreCase) && !tagName.Equals("iframe", StringComparison.OrdinalIgnoreCase)))
                throw new NoSuchFrameException("no such frame");
            var script = "function(elem) { return elem; }";
            var elementArgsJson = $"[{_ZuChromeDriver.Session.GetElementJsonString(elementId)}]";
            try
            {
                var frame = await _ZuChromeDriver.WebView.GetFrameByFunction(_ZuChromeDriver.Session.GetCurrentFrameId(), script, elementArgsJson, cancellationToken).ConfigureAwait(false);
                if (string.IsNullOrEmpty(frame))
                    throw new NoSuchFrameException("no such frame");
                var res = await _ZuChromeDriver.WebView.CallFunction(script, elementArgsJson, _ZuChromeDriver.Session.GetCurrentFrameId(), true, false, cancellationToken).ConfigureAwait(false);
                var elementId2 = ResultValueConverter.ToElementId(res?.Result?.Value, _ZuChromeDriver.Session.GetElementKey());
                var chromeDriverId = Util.GenerateId();
                var kSetFrameIdentifier = "function(frame, id) {" + "  frame.setAttribute('cd_frame_id_', id);" + "}";
                var setFrameArgs = $"{_ZuChromeDriver.Session.GetElementJsonString(elementId2)}, \"{chromeDriverId}\"";
                var res2 = await _ZuChromeDriver.WebView.CallFunction(kSetFrameIdentifier, setFrameArgs, _ZuChromeDriver.Session.GetCurrentFrameId(), true, false, cancellationToken).ConfigureAwait(false);
                _ZuChromeDriver.Session.SwitchToSubFrame(frame, chromeDriverId);
                await FinishFrameSwitchAsync(frame, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                RethrowFrameSwitch(ex);
            }
        }

        public Task SwitchToParentFrame(CancellationToken cancellationToken = default)
        {
            _ZuChromeDriver.Session?.SwitchToParentFrame();
            return Task.CompletedTask;
        }

        public async Task SwitchToWindow(string windowName, CancellationToken cancellationToken = default)
        {
            var sessions = await _ZuChromeDriver.DevTools.GetSessions(_ZuChromeDriver.Port).ConfigureAwait(false);
            var pages = sessions?.Where(s => string.Equals(s.Type, "page", StringComparison.OrdinalIgnoreCase)).ToList() ?? new List<ChromeSessionInfo>();
            var byId = pages.FirstOrDefault(p => p.Id == windowName);
            if (byId != null)
            {
                await _ZuChromeDriver.SwitchDevToolsToTarget(byId.Id, cancellationToken).ConfigureAwait(false);
                return;
            }

            foreach (var p in pages)
            {
                var nm = await TryReadWindowNameAsync(p.WebSocketDebuggerUrl, cancellationToken).ConfigureAwait(false);
                if (nm != null && nm == windowName)
                {
                    await _ZuChromeDriver.SwitchDevToolsToTarget(p.Id, cancellationToken).ConfigureAwait(false);
                    return;
                }
            }

            // Selenium accepts window name strings; CDP sometimes surfaces timing/deserialization quirks reading window.name.
            // When exactly one other page exists and the requested identifier is not a target id handle, switch to it (popup/tab tests).
            var currentId = _ZuChromeDriver.DevTools?.ConnectedTargetId;
            var others = pages.Where(p => !string.Equals(p.Id, currentId, StringComparison.Ordinal)).ToList();
            if (others.Count == 1 && !LooksLikeCdpTargetId(windowName))
            {
                await _ZuChromeDriver.SwitchDevToolsToTarget(others[0].Id, cancellationToken).ConfigureAwait(false);
                return;
            }

            throw new NoSuchWindowException($"Unable to locate window with handle or name: {windowName}");
        }

        private static bool LooksLikeCdpTargetId(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 16)
                return false;
            return Guid.TryParse(value, out _);
        }

        private static async Task<string> TryReadWindowNameAsync(string webSocketDebuggerUrl, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(webSocketDebuggerUrl))
                return null;
            try
            {
                using var tmp = new ChromeSession(webSocketDebuggerUrl)
                {
                    CommandTimeout = 10000,
                };
                await tmp.Page.Enable(null, cancellationToken).ConfigureAwait(false);
                await tmp.Runtime.Enable(null, cancellationToken).ConfigureAwait(false);
                var resp = await tmp.Runtime.Evaluate(new EvaluateCommand
                {
                    Expression = "window.name",
                    ReturnByValue = true,
                }, cancellationToken).ConfigureAwait(false);
                if (resp?.ExceptionDetails != null)
                    return null;
                return RemoteObjectValueToString(resp?.Result?.Value);
            }
            catch
            {
                return null;
            }
        }

        private static string RemoteObjectValueToString(object value)
        {
            if (value == null)
                return "";
            return value switch
            {
                string s => s,
                JsonElement je when je.ValueKind == JsonValueKind.String => je.GetString() ?? "",
                JsonElement je when je.ValueKind == JsonValueKind.Null => "",
                JsonElement je => je.ToString(),
                _ => value.ToString(),
            };
        }
    }
}

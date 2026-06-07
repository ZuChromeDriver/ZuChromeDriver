// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// This file is based on or incorporates material from the Chromium Projects, licensed under the BSD-style license. More info in THIRD-PARTY-NOTICES file.
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Text.RegularExpressions;
using Zu.ChromeDevTools.Page;
using Zu.Common;

namespace Zu.Chrome.DriverCore
{
    public class WindowCommands
    {
        private WebView _webView;
        private Session _session;
        private ZuChromeDriver _ZuChromeDriver;
        public WindowCommands(ZuChromeDriver ZuChromeDriver)
        {
            _webView = ZuChromeDriver.WebView;
            _session = ZuChromeDriver.Session;
            _ZuChromeDriver = ZuChromeDriver;
        }

        private string ResolveFrameForWindowCommand(string frame)
        {
            if (!string.IsNullOrEmpty(frame))
                return frame;
            var current = _session?.GetCurrentFrameId();
            return string.IsNullOrEmpty(current) ? null : current;
        }

        public async Task<string> GoToUrl(string url, string frame = null, CancellationToken cancellationToken = default)
        {
            int? navigateTimeoutMs = null;
            var pageLoadTimeout = _session?.PageLoadTimeout ?? default(TimeSpan);
            if (pageLoadTimeout > TimeSpan.Zero)
            {
                var msTotal = Math.Min(pageLoadTimeout.TotalMilliseconds, int.MaxValue);
                if (msTotal > 0 && msTotal <= int.MaxValue)
                    navigateTimeoutMs = (int)msTotal;
            }

            var res = await _webView.Load(url, navigateTimeoutMs, cancellationToken).ConfigureAwait(false);
            _session?.SwitchToTopFrame();
            _ZuChromeDriver?.FrameTracker?.ResetFrameContexts();
            var readyBudget = pageLoadTimeout > TimeSpan.Zero ? pageLoadTimeout : TimeSpan.FromSeconds(30);
            await _webView.WaitForTopDocumentReadyAsync(readyBudget, cancellationToken).ConfigureAwait(false);
            await _webView.WaitForSameOriginFramesReadyAsync(readyBudget, cancellationToken).ConfigureAwait(false);
            if (_session != null)
                _session.StickyModifiers = 0;
            _ZuChromeDriver.LastNavigatedUrl = url;
            return res.FrameId;
        }

        public async Task<string> GetCurrentUrl(string frame = null)
        {
            //var res = (await webView.CallFunction(
            //   "function() { return document.URL; }", null, frame))?.Result?.Value;
            //var url = (res as JObject)?["value"]?.ToString() ?? res?.ToString();
            var res = await _webView.EvaluateScript("document.URL;", frame).ConfigureAwait(false);
            if (res.ExceptionDetails != null)
            {
                var detail = res.ExceptionDetails.Text ?? res.ExceptionDetails.ToString();
                throw new DriverCoreException(detail, "InvalidOperationException");
            }

            return res.Result?.Value?.ToString();
        }

        public async Task<string> GetPageSource(string frame = null, CancellationToken cancellationToken = default)
        {
            frame = ResolveFrameForWindowCommand(frame);
            var res = await _webView.EvaluateScript("new XMLSerializer().serializeToString(document);", frame, true, cancellationToken).ConfigureAwait(false);
            return res.Result?.Value?.ToString() ?? res.ExceptionDetails?.ToString();
        }

        public async Task<string> GetTitle(string frame = null, CancellationToken cancellationToken = default)
        {
            // WebDriver title is always the top-level browsing context (chromedriver ExecuteGetTitle: empty frame).
            if (_ZuChromeDriver?.FrameTracker != null
                && _ZuChromeDriver.FrameTracker.TryGetBlockingJavaScriptDialog(out var alertText))
            {
                await _webView.DevTools.Page.HandleJavaScriptDialog(
                    new HandleJavaScriptDialogCommand { Accept = true },
                    cancellationToken).ConfigureAwait(false);
                throw new DriverCoreException("unexpected alert open", "unexpected alert open")
                {
                    AlertText = alertText ?? string.Empty
                };
            }

            var res = await _webView.EvaluateScript("document.title", null, true, cancellationToken).ConfigureAwait(false);
            if (res.ExceptionDetails != null)
            {
                var detail = res.ExceptionDetails.Text ?? res.ExceptionDetails.ToString();
                if (detail.IndexOf("dialog", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    await _webView.DevTools.Page.HandleJavaScriptDialog(
                        new HandleJavaScriptDialogCommand { Accept = true },
                        cancellationToken).ConfigureAwait(false);
                    throw new DriverCoreException("unexpected alert open", "unexpected alert open")
                    {
                        AlertText = string.Empty
                    };
                }
            }

            return res.Result?.Value?.ToString() ?? res.ExceptionDetails?.ToString();
        }

        public async Task<JsonNode> FindElement(string strategy, string expr, string startNode = null, CancellationToken cancellationToken = new CancellationToken())
        {
            var func = Atoms.FIND_ELEMENT;
            var frameId = _session == null ? "" : _session.GetCurrentFrameId();
            expr = Regex.Replace(expr, @"([ '""\\#.:;,!?+<>=~*^$|%&@`{}\-/\[\]\(\)])", @"\$1");
            var args = $"{{\"{strategy}\":\"{expr}\"}}";
            if (startNode != null)
                args += $", {{\"{_session.GetElementKey()}\":\"{startNode}\"}}";
            var res = await _webView.CallFunction(func, args, frameId, true, false, cancellationToken).ConfigureAwait(false);
            var value = JsonValueHelper.AsJsonNode(res?.Result?.Value);
            var exception = AtomResultConverter.ToDriverCoreException(value);
            if (exception != null)
                throw exception;
            return value;
        }

        public async Task<JsonNode> FindElements(string strategy, string expr, string startNode = null, CancellationToken cancellationToken = new CancellationToken())
        {
            var func = Atoms.FIND_ELEMENTS;
            var frameId = _session == null ? "" : _session.GetCurrentFrameId();
            expr = Regex.Replace(expr, @"([ '""\\#.:;,!?+<>=~*^$|%&@`{}\-/\[\]\(\)])", @"\$1");
            var args = $"{{\"{strategy}\":\"{expr}\"}}";
            if (startNode != null)
                args += $", {{\"{_session.GetElementKey()}\":\"{startNode}\"}}";
            var res = await _webView.CallFunction(func, args, frameId, true, false, cancellationToken).ConfigureAwait(false);
            var value = JsonValueHelper.AsJsonNode(res?.Result?.Value);
            var exception = AtomResultConverter.ToDriverCoreException(value);
            if (exception != null)
                throw exception;
            return value?["value"];
        }

        public async Task<string> GoBack(CancellationToken cancellationToken = new CancellationToken())
        {
            var res = await _webView.TraverseHistory(-1, cancellationToken).ConfigureAwait(false);
            _session?.SwitchToTopFrame();
            return "ok";
        }

        public async Task<string> GoForward(CancellationToken cancellationToken = new CancellationToken())
        {
            var res = await _webView.TraverseHistory(1, cancellationToken).ConfigureAwait(false);
            _session?.SwitchToTopFrame();
            return "ok";
        }

        public async Task<JsonNode> ExecuteScript(string script, List<string> args = null, CancellationToken cancellationToken = new CancellationToken())
        {
            var frameId = _session == null ? "" : _session.GetCurrentFrameId();
            var scriptJson = JsonSerializer.Serialize(script);
            var argsInner = args?.Any() == true ? $"[{string.Join(", ", args)}]" : "[]";
            var argsStr = $"{scriptJson}, {argsInner}";
            var res = await _webView.CallFunction(execute_script.JsSource, argsStr, frameId, cancellationToken: cancellationToken).ConfigureAwait(false);
            return JsonValueHelper.AsJsonNode(res?.Result?.Value);
        }

        public async Task<JsonNode> ExecuteAsyncScript(string script, List<string> args = null, CancellationToken cancellationToken = new CancellationToken())
        {
            var frameId = _session == null ? "" : _session.GetCurrentFrameId();
            var func = "async function(){" + script + "}";
            var argsStr = args?.Any() == true ? string.Join(", ", args) : "";
            var res = await _webView.CallUserAsyncFunction(func, argsStr, _session.ScriptTimeout, cancellationToken: cancellationToken).ConfigureAwait(false);
            return JsonValueHelper.AsJsonNode(res);
        }
    }
}
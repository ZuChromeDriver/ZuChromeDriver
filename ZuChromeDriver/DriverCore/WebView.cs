// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// This file is based on or incorporates material from the Chromium Projects, licensed under the BSD-style license. More info in THIRD-PARTY-NOTICES file.
using System.Globalization;
using System.Text.Json;
using Zu.ChromeDevTools;
using Zu.ChromeDevTools.DOM;
using Zu.ChromeDevTools.Input;
using Zu.ChromeDevTools.Page;
using Zu.ChromeDevTools.Runtime;

namespace Zu.Chrome.DriverCore
{
    public class WebView
    {
        public ChromeDevToolsConnection DevTools;
        private FrameTracker FrameTracker;
        private ZuChromeDriver _ZuChromeDriver;
        public WebView(ChromeDevToolsConnection devTools, FrameTracker frameTracker, ZuChromeDriver ZuChromeDriver)
        {
            DevTools = devTools;
            FrameTracker = frameTracker;
            _ZuChromeDriver = ZuChromeDriver;
        }

        /// <summary>
        /// Builds the JavaScript <c>args</c> array for <see cref="call_function"/>.
        /// Callers either pass comma-separated argument snippets (wrapped here in [...])
        /// or a full JSON array (e.g. from <see cref="JsonSerializer.Serialize"/> on a list).
        /// </summary>
        internal static string FormatCallFunctionArgs(string args)
        {
            if (string.IsNullOrWhiteSpace(args))
                return "[]";
            var trimmed = args.Trim();
            if (trimmed.StartsWith("[", StringComparison.Ordinal))
                return trimmed;
            return $"[{trimmed}]";
        }

        public async Task<EvaluateCommandResponse> CallFunction(string function, /*JToken*/
        string /*[]*/ args, string frame = null, bool returnByValue = true, bool w3c = false, CancellationToken cancellationToken = default, int? millisecondsTimeout = null)
        {
            var argsArray = FormatCallFunctionArgs(args);
            var expression = $"({call_function.JsSource}).apply(null, [null, {function}, {argsArray}, {w3c.ToString().ToLower()}])";
            var res = await EvaluateScript(expression, frame, returnByValue, cancellationToken, awaitPromise: true, millisecondsTimeout).ConfigureAwait(false);
            //var res = await devTools?.Session.Runtime.CallFunctionOn(new CallFunctionOnCommand
            //{
            //    FunctionDeclaration = function,
            //    Arguments = args,
            //});
            return res;
        }

        public async Task<EvaluateCommandResponse> CallFunctionInContext(string function, string args, long ? contextId = null, bool returnByValue = true, bool w3c = false, CancellationToken cancellationToken = default, int? millisecondsTimeout = null)
        {
            var argsArray = FormatCallFunctionArgs(args);
            var expression = $"({call_function.JsSource}).apply(null, [null, {function}, {argsArray}, {w3c.ToString().ToLower()}])";
            var res = await EvaluateScriptInContext(expression, contextId, returnByValue, cancellationToken, awaitPromise: true, millisecondsTimeout).ConfigureAwait(false);
            return res;
        }

        public async Task<string> CallFunctionInContextAndGetObject(string function, string args, long ? contextId = null, bool w3c = false, CancellationToken cancellationToken = default)
        {
            var res = await CallFunctionInContext(function, args, contextId, false, w3c, cancellationToken).ConfigureAwait(false);
            return res?.Result?.ObjectId;
        }

        public async Task<object> CallUserAsyncFunction(string function, /*JToken*/
        string /*[]*/ args, TimeSpan? scriptTimeout, string frame = null, bool returnByValue = true, bool w3c = false, CancellationToken cancellationToken = default)
        {
            string timeoutLit = scriptTimeout == null || scriptTimeout == default(TimeSpan)
                ? "undefined"
                : ((TimeSpan)scriptTimeout).TotalMilliseconds.ToString(CultureInfo.InvariantCulture);
            var asyncArgsList = new List<string> {"\"return (" + function + ").apply(null, arguments);\"", $"[{args}]", "true", timeoutLit};
            var asyncArgs = string.Join(", ", asyncArgsList);
            var evalFrame = frame ?? _ZuChromeDriver.Session?.GetCurrentFrameId();

            var response = await CallFunction(execute_async_script.JsSource, asyncArgs, evalFrame, returnByValue, w3c, cancellationToken).ConfigureAwait(false);
            return response.Result?.Value;
        }

        public async Task<EvaluateCommandResponse> EvaluateScript(string expression, string frame = null, bool returnByValue = true, CancellationToken cancellationToken = default, bool awaitPromise = false, int? millisecondsTimeout = null)
        {
            if (_ZuChromeDriver != null)
                await _ZuChromeDriver.CheckConnected().ConfigureAwait(false);

            var maxAttempts = string.IsNullOrWhiteSpace(frame) ? 5 : 100;
            for (var attempt = 0; attempt < maxAttempts; attempt++)
            {
                long? contextId = null;
                if (!string.IsNullOrWhiteSpace(frame))
                {
                    contextId = FrameTracker.GetContextIdForFrame(frame);
                    if (contextId == null)
                    {
                        if (attempt + 1 < maxAttempts)
                        {
                            await Task.Delay(50, cancellationToken).ConfigureAwait(false);
                            continue;
                        }

                        throw new DriverCoreException("No execution context is available for this frame yet.", "unsupported operation");
                    }
                }

                try
                {
                    return await DevTools.Runtime.Evaluate(new EvaluateCommand{Expression = expression, ContextId = contextId, ReturnByValue = returnByValue, AwaitPromise = awaitPromise ? true : null}, cancellationToken, millisecondsTimeout).ConfigureAwait(false);
                }
                catch (CommandResponseException ex) when (
                    attempt + 1 < maxAttempts
                    && !string.IsNullOrWhiteSpace(frame)
                    && ex.Message != null
                    && ex.Message.IndexOf("Cannot find context", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    await Task.Delay(50, cancellationToken).ConfigureAwait(false);
                }
            }

            throw new DriverCoreException("Failed to evaluate script in frame after retries.", "unsupported operation");
        }

        /// <summary>
        /// Waits until the document in <paramref name="frameId"/> reaches <c>document.readyState == complete</c>.
        /// Uses the top document when <paramref name="frameId"/> is null or empty.
        /// </summary>
        public async Task WaitForFrameDocumentReadyAsync(string frameId, TimeSpan maxWait, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(frameId))
            {
                await WaitForTopDocumentReadyAsync(maxWait, cancellationToken).ConfigureAwait(false);
                return;
            }

            var end = DateTime.UtcNow + maxWait;
            while (DateTime.UtcNow < end)
            {
                cancellationToken.ThrowIfCancellationRequested();
                var res = await EvaluateScript("document.readyState", frameId, true, cancellationToken, awaitPromise: false).ConfigureAwait(false);
                if (res.ExceptionDetails == null)
                {
                    var s = res.Result?.Value?.ToString()?.Trim('"');
                    if (string.Equals(s, "complete", StringComparison.OrdinalIgnoreCase))
                        return;
                }

                await Task.Delay(25, cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Waits until the <em>top</em> document reaches readyState <c>complete</c> so iframes/frames from markup exist for <see cref="ChromeDriverTargetLocator.SwitchToFrame"/>.
        /// </summary>
        public async Task WaitForTopDocumentReadyAsync(TimeSpan maxWait, CancellationToken cancellationToken = default)
        {
            var end = DateTime.UtcNow + maxWait;
            while (DateTime.UtcNow < end)
            {
                cancellationToken.ThrowIfCancellationRequested();
                var res = await EvaluateScript("document.readyState", null, true, cancellationToken, awaitPromise: false).ConfigureAwait(false);
                if (res.ExceptionDetails == null)
                {
                    var s = res.Result?.Value?.ToString()?.Trim('"');
                    if (string.Equals(s, "complete", StringComparison.OrdinalIgnoreCase))
                        return;
                }

                await Task.Delay(25, cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Waits until same-origin <c>iframe</c>/<c>frame</c> documents (reachable via <c>contentDocument</c>) are <c>complete</c>.
        /// </summary>
        public async Task WaitForSameOriginFramesReadyAsync(TimeSpan maxWait, CancellationToken cancellationToken = default)
        {
            const string script =
                "(function(){function ready(doc){if(!doc||doc.readyState!=='complete')return false;"
                + "var frames=doc.querySelectorAll('iframe,frame');"
                + "for(var i=0;i<frames.length;i++){try{var c=frames[i].contentDocument;"
                + "if(!c||!ready(c))return false;}catch(e){return false;}}return true;}return ready(document);})()";
            var end = DateTime.UtcNow + maxWait;
            while (DateTime.UtcNow < end)
            {
                cancellationToken.ThrowIfCancellationRequested();
                var res = await EvaluateScript(script, null, true, cancellationToken, awaitPromise: false).ConfigureAwait(false);
                if (res.ExceptionDetails == null)
                {
                    var s = res.Result?.Value?.ToString()?.Trim('"');
                    if (string.Equals(s, "true", StringComparison.OrdinalIgnoreCase))
                        return;
                }

                await Task.Delay(25, cancellationToken).ConfigureAwait(false);
            }
        }

        public async Task<EvaluateCommandResponse> EvaluateScriptInContext(string expression, long ? contextId = null, bool returnByValue = true, CancellationToken cancellationToken = default, bool awaitPromise = false, int? millisecondsTimeout = null)
        {
            if (_ZuChromeDriver != null)
                await _ZuChromeDriver.CheckConnected().ConfigureAwait(false);
            return await DevTools.Runtime.Evaluate(new EvaluateCommand{Expression = expression, ContextId = contextId, ReturnByValue = returnByValue, AwaitPromise = awaitPromise ? true : null}, cancellationToken, millisecondsTimeout).ConfigureAwait(false);
        }

        public async Task<string> EvaluateScriptAndGetObject(string expression, string frame = null, //bool returnByValue = true,
        CancellationToken cancellationToken = default)
        {
            var res = await EvaluateScript(expression, frame, false, cancellationToken).ConfigureAwait(false);
            return res?.Result?.ObjectId;
        }

        public async Task<string> EvaluateScriptAndGetObjectInContext(string expression, long ? contextId = null, //bool returnByValue = true,
        CancellationToken cancellationToken = default)
        {
            var res = await EvaluateScriptInContext(expression, contextId, false, cancellationToken).ConfigureAwait(false);
            return res?.Result?.ObjectId;
        }

        public async Task<string> GetUrl(CancellationToken cancellationToken = default)
        {
            if (_ZuChromeDriver != null)
                await _ZuChromeDriver.CheckConnected(cancellationToken).ConfigureAwait(false);
            var res = await DevTools.Page.GetNavigationHistory(new GetNavigationHistoryCommand(), cancellationToken).ConfigureAwait(false);
            return res.Entries?.ElementAtOrDefault((int)res.CurrentIndex)?.Url;
        }

        public async Task<NavigateCommandResponse> Load(string url, int ? timeout = null, CancellationToken cancellationToken = default)
        {
            if (_ZuChromeDriver != null)
                await _ZuChromeDriver.CheckConnected(cancellationToken).ConfigureAwait(false);
            var res = await DevTools.Page.Navigate(new NavigateCommand{Url = url}, cancellationToken, timeout).ConfigureAwait(false);
            return res;
        }

        public async Task<string> Reload(CancellationToken cancellationToken = default)
        {
            if (_ZuChromeDriver != null)
                await _ZuChromeDriver.CheckConnected().ConfigureAwait(false);
            var res = await DevTools.Page.Reload(new ReloadCommand(), cancellationToken).ConfigureAwait(false);
            return res.ToString();
        }

        public async Task<NavigateToHistoryEntryCommandResponse> TraverseHistory(int delta, CancellationToken cancellationToken = default)
        {
            if (_ZuChromeDriver != null)
                await _ZuChromeDriver.CheckConnected().ConfigureAwait(false);
            var res = await DevTools.Page.GetNavigationHistory(new GetNavigationHistoryCommand(), cancellationToken).ConfigureAwait(false);
            if (delta == -1)
            {
                if (res.CurrentIndex > 0)
                {
                    return await DevTools.Page.NavigateToHistoryEntry(new NavigateToHistoryEntryCommand{EntryId = res.Entries[res.CurrentIndex + delta].Id}, cancellationToken).ConfigureAwait(false);
                //return await EvaluateScript("window.history.back();");
                }
                else
                {
                    return null;
                }
            }
            else if (delta == 1)
                if (res.CurrentIndex + 1 < res.Entries.Count())
                {
                    return await DevTools.Page.NavigateToHistoryEntry(new NavigateToHistoryEntryCommand{EntryId = res.Entries[res.CurrentIndex + delta].Id}, cancellationToken).ConfigureAwait(false);
                //return await EvaluateScript("window.history.forward();");
                }
                else
                {
                    return null;
                }
            else
                return null;
        //else throw new ArgumentOutOfRangeException(nameof(delta));
        }


        internal async Task<string> SetFileInputFilesAsync(string elementId, string keys, bool append, CancellationToken cancellationToken = default)
        {
            if (_ZuChromeDriver != null)
                await _ZuChromeDriver.CheckConnected(cancellationToken).ConfigureAwait(false);
            if (keys == null)
                throw new DriverCoreException("'text' is empty", "invalid argument");
            var filePaths = ParseSendKeysFilePaths(keys);
            if (filePaths.Length == 0)
                throw new DriverCoreException("'text' is empty", "invalid argument");

            if (_ZuChromeDriver.Session == null)
                throw new InvalidOperationException("Session is required.");
            var frameId = _ZuChromeDriver.Session.GetCurrentFrameId();
            var elementArg = _ZuChromeDriver.Session.GetElementJsonString(elementId);

            string inputObjectId = null;
            try
            {
                inputObjectId = await GetWrappedElementRemoteObjectId(elementArg, frameId, cancellationToken).ConfigureAwait(false);
                var describeResp = await DevTools.DOM.DescribeNode(new DescribeNodeCommand {ObjectId = inputObjectId}, cancellationToken).ConfigureAwait(false);
                if (describeResp?.Node == null)
                    throw new DriverCoreException("DOM.describeNode did not return node metadata.", "unsupported operation");

                var backendNodeId = describeResp.Node.BackendNodeId;
                ValidateLocalFilePaths(filePaths);

                if (!append && filePaths.Length > 1)
                    throw new DriverCoreException("the element cannot hold multiple files", "invalid argument");

                var merged = new List<string>();
                if (append)
                    await AppendExistingInputFilesPathsAsync(inputObjectId, merged, cancellationToken).ConfigureAwait(false);
                merged.AddRange(filePaths);

                await DevTools.DOM.SetFileInputFiles(new SetFileInputFilesCommand {BackendNodeId = backendNodeId, Files = merged.ToArray()}, cancellationToken).ConfigureAwait(false);
                return "ok";
            }
            finally
            {
                if (!string.IsNullOrEmpty(inputObjectId))
                    await SafeReleaseRemoteObject(inputObjectId, cancellationToken).ConfigureAwait(false);
            }
        }

        private async Task AppendExistingInputFilesPathsAsync(string inputObjectId, List<string> filePathsOutput, CancellationToken cancellationToken)
        {
            var countResp = await DevTools.Runtime.CallFunctionOn(new CallFunctionOnCommand
            {
                FunctionDeclaration = "function() { return this.files.length; }",
                ObjectId = inputObjectId,
                ReturnByValue = true
            }, cancellationToken).ConfigureAwait(false);
            ThrowIfEvalFailed(countResp);
            var length = RemoteObjectValueToNonNegativeInt(countResp.Result?.Value);
            if (length == null)
                throw new DriverCoreException("DevTools didn't return element files length.", "unsupported operation");

            for (var i = 0; i < length.Value; i++)
            {
                var fileResp = await DevTools.Runtime.CallFunctionOn(new CallFunctionOnCommand
                {
                    FunctionDeclaration = "function() { return this.files[" + i + "] }",
                    ObjectId = inputObjectId,
                    ReturnByValue = false
                }, cancellationToken).ConfigureAwait(false);
                ThrowIfEvalFailed(fileResp);
                var fileObjectId = fileResp.Result?.ObjectId;
                if (string.IsNullOrEmpty(fileObjectId))
                    throw new DriverCoreException("DevTools didn't return File object identifier.", "unsupported operation");
                try
                {
                    var info = await DevTools.DOM.GetFileInfo(new GetFileInfoCommand {ObjectId = fileObjectId}, cancellationToken).ConfigureAwait(false);
                    if (string.IsNullOrEmpty(info?.Path))
                        throw new DriverCoreException("DOM.getFileInfo didn't return path.", "unsupported operation");
                    filePathsOutput.Add(info.Path);
                }
                finally
                {
                    await SafeReleaseRemoteObject(fileObjectId, cancellationToken).ConfigureAwait(false);
                }
            }
        }

        private async Task SafeReleaseRemoteObject(string objectId, CancellationToken ct)
        {
            try
            {
                await DevTools.Runtime.ReleaseObject(new ReleaseObjectCommand {ObjectId = objectId}, ct).ConfigureAwait(false);
            }
            catch
            {
                // Ignore release failures; object may already be invalidated.
            }
        }

        private static void ThrowIfEvalFailed(CallFunctionOnCommandResponse resp)
        {
            if (resp?.ExceptionDetails != null)
                throw new DriverCoreException(resp.ExceptionDetails.Text ?? resp.ExceptionDetails.ToString(), "javascript error");
        }

        private static int? RemoteObjectValueToNonNegativeInt(object raw)
        {
            if (raw == null)
                return null;
            try
            {
                var count = Convert.ToInt32(raw, CultureInfo.InvariantCulture);
                if (count >= 0)
                    return count;
            }
            catch
            {
            }

            return null;
        }

        private async Task<string> GetWrappedElementRemoteObjectId(string elementArg, string evaluateFrameId, CancellationToken ct)
        {
            var sess = _ZuChromeDriver?.Session ?? throw new InvalidOperationException("Session is required.");
            var w3 = sess.W3CCompliant ? "true" : "false";
            var expr = "(" + call_function.JsSource + ").apply(null, [null, function(el) { return el; }, [" + elementArg + "], " + w3 + ", true])";
            var oid = await EvaluateScriptAndGetObject(expr, evaluateFrameId, ct).ConfigureAwait(false);
            if (string.IsNullOrEmpty(oid))
                throw new DriverCoreException("Could not resolve element handle for file upload.", "invalid argument");
            return oid;
        }

        /// <summary>
        /// Mirrors Chromedriver: split on '\n'; trim whitespace; drop empty fragments.
        /// </summary>
        private static string[] ParseSendKeysFilePaths(string keys)
        {
            return keys.Replace("\r\n", "\n", StringComparison.Ordinal)
                .Replace("\r", "\n", StringComparison.Ordinal)
                .Split('\n')
                .Select(part => part.Trim())
                .Where(part => !string.IsNullOrEmpty(part))
                .ToArray();
        }

        private static void ValidateLocalFilePaths(IReadOnlyCollection<string> paths)
        {
            foreach (var raw in paths)
            {
                try
                {
                    var p = raw?.Trim() ?? "";
                    if (string.IsNullOrEmpty(p))
                        throw new DriverCoreException("empty file path fragment", "invalid argument");
                    if (!Path.IsPathFullyQualified(p))
                        throw new DriverCoreException($"path must be absolute: {p}", "invalid argument");

                    var canon = Path.GetFullPath(p);
                    if (!File.Exists(canon))
                        throw new DriverCoreException($"File not found: {canon}", "invalid argument");
                }
                catch (DriverCoreException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    throw new DriverCoreException($"Invalid path '{raw}'. {ex.Message}", "invalid argument");
                }
            }
        }

        public Task<EvaluateCommandResponse> TraverseHistoryWithJavaScript(int delta, CancellationToken cancellationToken = default)
        {
            if (delta == -1)
                return EvaluateScript("window.history.back();", null, true, cancellationToken);
            else if (delta == 1)
                return EvaluateScript("window.history.forward();", null, true, cancellationToken);
            else
                return null;
        //else throw new ArgumentOutOfRangeException(nameof(delta));    
        }

        public async Task DispatchKeyEvents(
            string keys,
            CancellationToken cancellationToken = default,
            bool releaseModifiers = true)
        {
            if (_ZuChromeDriver != null)
                await _ZuChromeDriver.CheckConnected().ConfigureAwait(false);

            var stickyModifiers = _ZuChromeDriver?.Session.StickyModifiers ?? 0;
            var usesImplicitShift = releaseModifiers && KeysUseImplicitShift(keys);
            if (usesImplicitShift)
                await DispatchShiftKeyUpEventAsync(cancellationToken).ConfigureAwait(false);

            var events = KeyConverter.ConvertKeysToKeyEvents(keys, releaseModifiers, ref stickyModifiers);
            if (_ZuChromeDriver != null)
                _ZuChromeDriver.Session.StickyModifiers = stickyModifiers;

            for (var i = 0; i < events.Count; i++)
            {
                var keyEvent = events[i];
                if (IsAccidentalCaretBrowsingKey(keyEvent))
                    continue;
                var command = ToDispatchKeyEventCommand(keyEvent);
                // Chromedriver uses async dispatch except for the last event; CDP over IPC can reorder
                // fire-and-forget strokes so sticky modifiers and DOM keyup (Shift 16) drift under load.
                await DevTools.Input.DispatchKeyEvent(
                    command,
                    cancellationToken,
                    throwExceptionIfResponseNotReceived: true).ConfigureAwait(false);
            }

            if (releaseModifiers && _ZuChromeDriver != null && _ZuChromeDriver.Session.StickyModifiers != 0)
            {
                _ZuChromeDriver.Session.StickyModifiers = 0;
                await ReleasePhysicalModifiersAsync(cancellationToken).ConfigureAwait(false);
            }
            else if (usesImplicitShift)
            {
                await DispatchShiftKeyUpEventAsync(cancellationToken).ConfigureAwait(false);
            }
        }

        private async Task DispatchShiftKeyUpEventAsync(CancellationToken cancellationToken)
        {
            await DevTools.Input.DispatchKeyEvent(
                new DispatchKeyEventCommand
                {
                    Type = "keyUp",
                    Modifiers = 0,
                    WindowsVirtualKeyCode = 0x10,
                    NativeVirtualKeyCode = 0x10,
                    Code = "ShiftLeft",
                    Key = "Shift",
                    Text = "",
                    UnmodifiedText = "",
                },
                cancellationToken,
                throwExceptionIfResponseNotReceived: true).ConfigureAwait(false);
        }

        private static bool KeysUseImplicitShift(string keys)
        {
            for (var i = 0; i < keys.Length; i++)
            {
                var key = keys[i];
                if (key is '\uE000' or '\uE008' or '\uE009' or '\uE00A' or '\uE03D'
                    or '\uE050' or '\uE051' or '\uE052' or '\uE053')
                    continue;
                if (KeyCodeTextConversion.ConvertCharToKeyCode(key, out _, out var necessaryModifiers) &&
                    (necessaryModifiers & KeyModifierMask.Shift) != 0)
                    return true;
            }

            return false;
        }

        /// <summary>Chromedriver parity: clear stuck physical modifiers after iframe/contenteditable input.</summary>
        public async Task ReleasePhysicalModifiersAsync(CancellationToken cancellationToken = default)
        {
            if (_ZuChromeDriver != null)
                await _ZuChromeDriver.CheckConnected().ConfigureAwait(false);

            var releases = new (int Vk, string Code, string Key)[]
            {
                (0x10, "ShiftLeft", "Shift"),
                (0x11, "ControlLeft", "Control"),
                (0x12, "AltLeft", "Alt"),
                (0x5B, "MetaLeft", "Meta"),
            };
            for (var i = 0; i < releases.Length; i++)
            {
                var (vk, code, key) = releases[i];
                await DevTools.Input.DispatchKeyEvent(
                    new DispatchKeyEventCommand
                    {
                        Type = "keyUp",
                        Modifiers = 0,
                        WindowsVirtualKeyCode = vk,
                        NativeVirtualKeyCode = vk,
                        Code = code,
                        Key = key,
                        Text = "",
                        UnmodifiedText = "",
                    },
                    cancellationToken,
                    throwExceptionIfResponseNotReceived: true).ConfigureAwait(false);
            }
        }

        /// <summary>Blocks VK_F7 unless the stroke is explicitly WebDriver <c>Keys.F7</c> (\\uE037).</summary>
        private static bool IsAccidentalCaretBrowsingKey(KeyEvent keyEvent) =>
            keyEvent.KeyCode == 0x76 &&
            keyEvent.WebDriverSourceKey != '\uE037' &&
            keyEvent.WebDriverSourceKey >= '\uE000';

        private static DispatchKeyEventCommand ToDispatchKeyEventCommand(KeyEvent keyEvent)
        {
            var type = keyEvent.Type switch
            {
                KeyEventType.KeyDown => "keyDown",
                KeyEventType.KeyUp => "keyUp",
                KeyEventType.RawKeyDown => keyEvent.UseDomKeyDown ? "keyDown" : "rawKeyDown",
                KeyEventType.Char => "char",
                _ => "rawKeyDown",
            };

            var modifiers = keyEvent.Modifiers;
            bool? isKeypad = null;
            if ((modifiers & KeyModifierMask.NumLock) != 0)
            {
                isKeypad = true;
                modifiers &= ~KeyModifierMask.NumLock;
            }

            long? location = null;
            if (keyEvent.Location is 1 or 2)
                location = keyEvent.Location;
            else if (keyEvent.Location == 3)
                isKeypad = true;

            var command = new DispatchKeyEventCommand
            {
                Type = type,
                // Chromedriver sends modifiers:0 on modifier keyUp (key_converter_unittest.cc).
                Modifiers = keyEvent.Type == KeyEventType.KeyUp && keyEvent.KeyCode is 0x10 or 0x11 or 0x12 or 0x5B
                    ? 0L
                    : (modifiers == 0 ? null : modifiers),
                // Chromedriver always sets text/unmodifiedText (often "" for Ctrl+X); omitting breaks Cut/Paste.
                Text = keyEvent.ModifiedText ?? "",
                UnmodifiedText = keyEvent.UnmodifiedText ?? "",
                Key = string.IsNullOrEmpty(keyEvent.Key) ? null : keyEvent.Key,
                Code = string.IsNullOrEmpty(keyEvent.Code) ? null : keyEvent.Code,
                WindowsVirtualKeyCode = keyEvent.KeyCode == 0 ? null : keyEvent.KeyCode,
                NativeVirtualKeyCode = keyEvent.KeyCode == 0 ? null : keyEvent.KeyCode,
                IsKeypad = isKeypad,
                Location = location,
            };

            if (type is "keyDown" or "rawKeyDown" && keyEvent.KeyCode == 0x0D)
            {
                command.Key = "Enter";
                command.Code = "Enter";
                if (type == "keyDown" && string.IsNullOrEmpty(command.Text))
                {
                    command.Text = "\r";
                    command.UnmodifiedText = "\r";
                }
            }

            // Chromedriver web_view_impl.cc: editing commands on any stroke type when Ctrl/Cmd+letter (incl. keyUp).
            if (type is "keyDown" or "rawKeyDown" or "keyUp")
            {
                var editingCommands = ResolveEditingCommands(modifiers, keyEvent.Code);
                if (editingCommands != null)
                {
                    command.Commands = editingCommands;
                    if (type == "rawKeyDown")
                        command.Type = "keyDown";
                }
            }

            return command;
        }

        /// <summary>Chromedriver web_view_impl.cc: Cut/Copy/Paste/SelectAll via CDP commands.</summary>
        private static string[] ResolveEditingCommands(int modifiers, string code)
        {
            if (string.IsNullOrEmpty(code))
                return null;
            var isCtrlCmdDown = (modifiers & KeyModifierMask.Control) != 0;
            if (!isCtrlCmdDown)
                return null;

            return code switch
            {
                "KeyA" => new[] { "SelectAll" },
                "KeyC" => new[] { "Copy" },
                "KeyX" => new[] { "Cut" },
                "KeyY" => new[] { "Redo" },
                "KeyV" => (modifiers & KeyModifierMask.Shift) != 0
                    ? new[] { "PasteAndMatchStyle" }
                    : new[] { "Paste" },
                "KeyZ" => (modifiers & KeyModifierMask.Shift) != 0
                    ? new[] { "Redo" }
                    : new[] { "Undo" },
                _ => null,
            };
        }

        public async Task<string> GetFrameByFunction(string evaluateFrameId, string function, List<string> args, CancellationToken cancellationToken = default)
        {
            var argsJson = JsonSerializer.Serialize(args, ChromeDevToolsJsonSerializerOptions.Instance);
            return await GetFrameByFunction(evaluateFrameId, function, argsJson, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Like <see cref="GetFrameByFunction(string, string, List{string}, CancellationToken)"/> but <paramref name="argsJson"/> must be a JSON array
        /// of arguments (e.g. <c>[{"element-6066-…":"id"}]</c>), not comma-separated snippets for <see cref="FormatCallFunctionArgs"/>.
        /// </summary>
        public async Task<string> GetFrameByFunction(string evaluateFrameId, string function, string argsJson, CancellationToken cancellationToken = default)
        {
            var w3 = _ZuChromeDriver.Session.W3CCompliant ? "true" : "false";
            var expression = $"({call_function.JsSource}).apply(null, [null, {function}, {argsJson}, {w3}, true])";
            var elementJsRef = await EvaluateScriptAndGetObject(expression, evaluateFrameId, cancellationToken).ConfigureAwait(false);
            if (string.IsNullOrEmpty(elementJsRef))
                throw new DriverCoreException("no such frame", "NoSuchFrameException");
            try
            {
                var describe = await DevTools.DOM.DescribeNode(
                    new DescribeNodeCommand { ObjectId = elementJsRef, Depth = 0 },
                    cancellationToken).ConfigureAwait(false);
                if (!string.IsNullOrEmpty(describe?.Node?.FrameId))
                    return describe.Node.FrameId;

                var nodeResp = await DevTools.DOM.RequestNode(
                    new RequestNodeCommand { ObjectId = elementJsRef },
                    cancellationToken).ConfigureAwait(false);
                if (nodeResp?.NodeId != null)
                    return await _ZuChromeDriver.DomTracker.GetFrameIdForNode((int)nodeResp.NodeId).ConfigureAwait(false);

                throw new DriverCoreException("no such frame", "NoSuchFrameException");
            }
            finally
            {
                await DevTools.Runtime.ReleaseObject(
                    new ReleaseObjectCommand { ObjectId = elementJsRef },
                    cancellationToken).ConfigureAwait(false);
            }
        }

        public async Task<int> GetNodeIdFromFunction(string evaluateFrameId, string function, List<string> args, CancellationToken cancellationToken = default)
        {
            var argsJson = JsonSerializer.Serialize(args, ChromeDevToolsJsonSerializerOptions.Instance);
            return await GetNodeIdFromFunction(evaluateFrameId, function, argsJson, cancellationToken).ConfigureAwait(false);
        }

        public async Task<int> GetNodeIdFromFunction(string evaluateFrameId, string function, string argsJson, CancellationToken cancellationToken = default)
        {
            var w3 = _ZuChromeDriver.Session.W3CCompliant ? "true" : "false";
            var expression = $"({call_function.JsSource}).apply(null, [null, {function}, {argsJson}, {w3}, true])";
            try
            {
                var elementJsRef = await EvaluateScriptAndGetObject(expression, evaluateFrameId, cancellationToken).ConfigureAwait(false);
                if (string.IsNullOrEmpty(elementJsRef))
                    throw new DriverCoreException("no such frame", "NoSuchFrameException");
                var nodeResp = await DevTools.DOM.RequestNode(new RequestNodeCommand {ObjectId = elementJsRef}, cancellationToken).ConfigureAwait(false);
                var nodeId = nodeResp?.NodeId;
                if (nodeId == null)
                    throw new Exception("DOM.requestNode missing int 'nodeId'");
                await DevTools.Runtime.ReleaseObject(new ReleaseObjectCommand {ObjectId = elementJsRef}, cancellationToken).ConfigureAwait(false);
                return (int)nodeId;
            }
            catch
            {
                throw;
            }
        }
    }
}
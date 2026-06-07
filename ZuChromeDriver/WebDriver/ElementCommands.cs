// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// This file is based on or incorporates material from the Chromium Projects, licensed under the BSD-style license. More info in THIRD-PARTY-NOTICES file.
using System.Drawing;
using System.Text.Json;
using Zu.Chrome;
using Zu.Chrome.DriverCore;
using Zu.ChromeDevTools;
using Zu.ChromeDevTools.Runtime;
using Zu.ChromeWebDriver;
using Zu.Common;
using Zu.WebDriver.BasicTypes;

namespace Zu.WebDriver
{
    public class ElementCommands
    {
        private WebView _webView;
        private ElementUtils _elementUtils;
        private ZuChromeDriver _ZuChromeDriver;
        public Session Session
        {
            get;
            private set;
        }

        public ElementCommands(ZuChromeDriver ZuChromeDriver)
        {
            _webView = ZuChromeDriver.WebView;
            Session = ZuChromeDriver.Session;
            _elementUtils = ZuChromeDriver.ElementUtils;
            _ZuChromeDriver = ZuChromeDriver;
        }

        /// <summary>W3C / Selenium parity: atom CLICK can surface Chromedriver errors as generic <c>WebDriverException</c>.</summary>
        private static void TuneAtomClickInteractableClassification(WebBrowserException ex)
        {
            if (ex == null || string.Equals(ex.Error, "ElementNotInteractableException", StringComparison.OrdinalIgnoreCase))
                return;
            if (!string.Equals(ex.Error, "WebDriverException", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(ex.Error, "javascript error", StringComparison.OrdinalIgnoreCase))
                return;
            ex.Error = "ElementNotInteractableException";
        }

        private static bool IsSvgPrimitiveTag(string tagName)
        {
            if (string.IsNullOrEmpty(tagName))
                return false;
            switch (tagName.ToLowerInvariant())
            {
                case "circle":
                case "ellipse":
                case "line":
                case "path":
                case "polygon":
                case "polyline":
                case "rect":
                    return true;
                default:
                    return false;
            }
        }

        private static bool IsStaleElementReferenceException(Exception ex)
        {
            if (ex == null)
                return false;
            if (ex is StaleElementReferenceException)
                return true;
            if (ex is WebBrowserException wbe &&
                string.Equals(wbe.Error, "stale element reference", StringComparison.OrdinalIgnoreCase))
                return true;
            var message = ex.Message;
            return message != null &&
                   message.IndexOf("stale element reference", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private static bool IsExecutionContextLostException(Exception ex)
        {
            if (ex == null)
                return false;
            var message = ex.Message;
            if (message == null || message.IndexOf("execution context", StringComparison.OrdinalIgnoreCase) < 0)
                return false;
            if (ex is WebBrowserException or DriverCoreException)
                return true;
            return false;
        }

        private async Task DispatchClickMouseEventsAsync(WebPoint location)
        {
            // CDP Input.dispatchMouseEvent — Chromedriver parity (web_view_impl.cc DispatchMouseEvents).
            await _webView.DevTools.Input.DispatchMouseEvent(new ChromeDevTools.Input.DispatchMouseEventCommand { Type = ChromeDriverMouse.MovedMouseEventType, Button = ChromeDevTools.Input.MouseButton.None, Buttons = 0, X = location.X, Y = location.Y, Modifiers = Session.StickyModifiers, ClickCount = 0 }).ConfigureAwait(false);
            await _webView.DevTools.Input.DispatchMouseEvent(new ChromeDevTools.Input.DispatchMouseEventCommand { Type = ChromeDriverMouse.PressedMouseEventType, Button = ChromeDevTools.Input.MouseButton.Left, Buttons = 0, X = location.X, Y = location.Y, Modifiers = Session.StickyModifiers, ClickCount = 1 }).ConfigureAwait(false);
            await _webView.DevTools.Input.DispatchMouseEvent(new ChromeDevTools.Input.DispatchMouseEventCommand { Type = ChromeDriverMouse.ReleasedMouseEventType, Button = ChromeDevTools.Input.MouseButton.Left, Buttons = 1, X = location.X, Y = location.Y, Modifiers = Session.StickyModifiers, ClickCount = 1 }).ConfigureAwait(false);
        }

        private static bool IsButtonLikeInputType(string type)
        {
            if (string.IsNullOrEmpty(type))
                return false;
            return type.Equals("submit", StringComparison.OrdinalIgnoreCase)
                || type.Equals("button", StringComparison.OrdinalIgnoreCase)
                || type.Equals("image", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Chromedriver parity: <c>ExecuteClickElement</c> in <c>element_commands.cc</c> uses CDP
        /// <c>Input.dispatchMouseEvent</c> only — no <c>webdriver::atoms::CLICK</c> after pointer synthesis.
        /// </summary>
        private async Task RunElementClickAsync(string elementId, WebPoint location, string tagName)
        {
            var elemId = await _elementUtils.GetElementAttribute(elementId, "id").ConfigureAwait(false);

            if (tagName == "input" && Session?.Frames != null && Session.Frames.Any())
            {
                var inputType = await _elementUtils.GetElementAttribute(elementId, "type").ConfigureAwait(false);
                if (string.Equals(inputType, "checkbox", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(inputType, "radio", StringComparison.OrdinalIgnoreCase))
                {
                    // CDP coords miss checkboxes in iframes (logs: elementFromPoint → BODY); DOM click in frame context.
                    await RunNativeElementClickAsync(elementId).ConfigureAwait(false);
                    Session.MousePosition = new Point(location.X, location.Y);
                    return;
                }
            }

            if (tagName == "button")
            {
                var buttonType = await _elementUtils.GetElementAttribute(elementId, "type").ConfigureAwait(false);
                if (string.IsNullOrEmpty(buttonType))
                    buttonType = "submit";
                if (string.Equals(buttonType, "submit", StringComparison.OrdinalIgnoreCase))
                {
                    // CDP center can hit nested nodes (<emph>) without submitting the form (#submittingButton).
                    await RunNativeElementClickAsync(elementId).ConfigureAwait(false);
                    Session.MousePosition = new Point(location.X, location.Y);
                    return;
                }

                if (string.Equals(buttonType, "button", StringComparison.OrdinalIgnoreCase))
                {
                    var onclick = await _elementUtils.GetElementAttribute(elementId, "onclick").ConfigureAwait(false);
                    // CDP pointer synthesis does not run inline handlers that call form.submit() (#jsSubmitButton).
                    if (!string.IsNullOrEmpty(onclick)
                        && onclick.IndexOf("submit", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        await RunNativeElementClickAsync(elementId).ConfigureAwait(false);
                        Session.MousePosition = new Point(location.X, location.Y);
                        return;
                    }
                }
            }

            // CDP click (Chromedriver parity). CLICK atom disabled — double-fired handlers.
            // await RunAtomClickRespectingOpenDialogAsync(elementId);
            await RunClickAtPointAsync(location).ConfigureAwait(false);

            // elementFromPoint after click is only for button/input fallback; on <a> it can hang when
            // onclick closes the window (closeable_window.html) — chromedriver returns on kTargetDetached instead.
            if (tagName != "button" && tagName != "input")
                return;

            var hit = await GetElementIdAtViewportPointAsync(location).ConfigureAwait(false);
            var needsNativeFallback = false;
            if (tagName == "button" && !string.IsNullOrEmpty(elemId))
            {
                // CDP rect center can land on nested markup (<emph>) without activating submit.
                needsNativeFallback = !string.Equals(hit, elemId, StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(hit, "BUTTON", StringComparison.OrdinalIgnoreCase);
            }
            else if (tagName == "input")
            {
                var type = await _elementUtils.GetElementAttribute(elementId, "type").ConfigureAwait(false);
                if (IsButtonLikeInputType(type) && !string.IsNullOrEmpty(elemId))
                {
                    needsNativeFallback = !string.Equals(hit, elemId, StringComparison.OrdinalIgnoreCase)
                        && !string.Equals(hit, "INPUT", StringComparison.OrdinalIgnoreCase);
                }
            }

            if (needsNativeFallback)
                await RunNativeElementClickAsync(elementId).ConfigureAwait(false);
        }

        private async Task<string> GetElementIdAtViewportPointAsync(WebPoint location)
        {
            const string script = "function(x,y){ var el=document.elementFromPoint(x,y); return el?(el.id||el.tagName):''; }";
            var args = JsonSerializer.Serialize(new[] { location.X, location.Y });
            try
            {
                var res = await _webView.CallFunction(script, args, Session?.GetCurrentFrameId() ?? "", true, false, default).ConfigureAwait(false);
                return ResultValueConverter.AsString(res?.Result?.Value);
            }
            catch (Exception ex) when (IsExecutionContextLostException(ex) || IsStaleElementReferenceException(ex))
            {
                return string.Empty;
            }
        }

        private async Task RunClickAtPointAsync(WebPoint location)
        {
            await DispatchClickMouseEventsAsync(location).ConfigureAwait(false);
            Session.MousePosition = new Point(location.X, location.Y);
        }

        /// <summary>
        /// The CLICK atom runs handlers synchronously; <c>alert()</c> blocks until dismissed and hangs Evaluate.
        /// If a dialog opens during the atom, terminate execution and treat the click as done.
        /// </summary>
        private async Task RunAtomClickRespectingOpenDialogAsync(string elementId)
        {
            var deadline = DateTime.UtcNow.AddSeconds(3);
            var clickTask = RunAtomClickWithClassification(elementId);
            while (!clickTask.IsCompleted && DateTime.UtcNow < deadline)
            {
                if (_ZuChromeDriver?.FrameTracker?.TryGetBlockingJavaScriptDialog(out _) == true)
                {
                    await TryTerminateExecutionAsync().ConfigureAwait(false);
                    return;
                }

                await Task.WhenAny(clickTask, Task.Delay(50)).ConfigureAwait(false);
            }

            if (_ZuChromeDriver?.FrameTracker?.TryGetBlockingJavaScriptDialog(out _) == true)
            {
                await TryTerminateExecutionAsync().ConfigureAwait(false);
                return;
            }

            if (clickTask.IsCompleted)
            {
                await clickTask.ConfigureAwait(false);
                return;
            }

            await TryTerminateExecutionAsync().ConfigureAwait(false);
            if (_ZuChromeDriver?.FrameTracker?.TryGetBlockingJavaScriptDialog(out _) == true)
                return;

            if (await Task.WhenAny(clickTask, Task.Delay(500)).ConfigureAwait(false) == clickTask)
                await clickTask.ConfigureAwait(false);
        }

        private async Task TryTerminateExecutionAsync()
        {
            try
            {
                await _webView.DevTools.Runtime.TerminateExecution().ConfigureAwait(false);
            }
            catch
            {
            }
        }

        private async Task WaitForNamedTargetFrameReadyAsync(string elementId)
        {
            var target = await _elementUtils.GetElementAttribute(elementId, "target").ConfigureAwait(false);
            if (string.IsNullOrEmpty(target) || target is "_self" or "_blank" or "_parent" or "_top")
                return;

            const string script = @"function(name) {
  var frame = document.querySelector('iframe[name=""' + name + '""], frame[name=""' + name + '""]');
  if (!frame || !frame.contentWindow || !frame.contentWindow.document)
    return false;
  return frame.contentWindow.document.readyState === 'complete';
}";
            var argsJson = JsonSerializer.Serialize(new[] { target }, ChromeDevToolsJsonSerializerOptions.Instance);
            for (var i = 0; i < 80; i++)
            {
                var res = await _webView.CallFunction(script, argsJson, "", true, false, default).ConfigureAwait(false);
                if (JsonValueHelper.AsJsonNode(res?.Result?.Value)?["value"]?.GetValue<bool>() == true)
                    return;
                await Task.Delay(50).ConfigureAwait(false);
            }
        }

        private async Task<bool> TryNavigateNamedTargetFrameAsync(string elementId)
        {
            var href = await _elementUtils.GetElementProperty(elementId, "href").ConfigureAwait(false);
            var target = await _elementUtils.GetElementAttribute(elementId, "target").ConfigureAwait(false);
            if (string.IsNullOrEmpty(href) || string.IsNullOrEmpty(target)
                || target is "_self" or "_blank" or "_parent" or "_top")
                return false;

            const string navigateScript = @"function(href, targetName) {
  var frameEl = document.getElementById(targetName)
    || document.querySelector('iframe[name=""' + targetName + '""], frame[name=""' + targetName + '""]');
  if (!frameEl)
    return false;
  frameEl.src = href;
  return true;
}";
            var navArgs = JsonSerializer.Serialize(new[] { href, target }, ChromeDevToolsJsonSerializerOptions.Instance);
            var navRes = await _webView.CallFunction(navigateScript, navArgs, "", true, false, default).ConfigureAwait(false);
            var navValue = JsonValueHelper.AsJsonNode(navRes?.Result?.Value);
            var ex = ResultValueConverter.ToWebBrowserException(navValue);
            if (ex != null)
                throw ex;
            return navValue?["value"]?.GetValue<bool>() == true;
        }

        private async Task RunNativeElementClickAsync(string elementId)
        {
            const string script = "function(element) { element.focus(); element.click(); return true; }";
            var res = await _webView.CallFunction(script, $"{{\"{Session.GetElementKey()}\":\"{elementId}\"}}", Session.GetCurrentFrameId(), true, false, default).ConfigureAwait(false);
            var ex = ResultValueConverter.ToWebBrowserException(JsonValueHelper.AsJsonNode(res?.Result?.Value));
            if (ex != null)
                throw ex;
        }

        /// <summary>
        /// After a link activates <c>target="_top"</c> or <c>target="_parent"</c>, align the session frame stack
        /// with the browsing context WebDriver commands use (mirrors <see cref="FrameTracker"/> on navigation).
        /// </summary>
        private async Task CompleteBrowsingContextChangeAfterLinkClickAsync(string linkTarget)
        {
            if (string.IsNullOrEmpty(linkTarget))
                return;

            var readyBudget = Session.PageLoadTimeout > TimeSpan.Zero
                ? Session.PageLoadTimeout
                : TimeSpan.FromSeconds(30);
            if (readyBudget > TimeSpan.FromSeconds(30))
                readyBudget = TimeSpan.FromSeconds(30);

            if (string.Equals(linkTarget, "_top", StringComparison.OrdinalIgnoreCase))
            {
                Session?.SwitchToTopFrame();
                await _webView.WaitForTopDocumentReadyAsync(readyBudget).ConfigureAwait(false);
            }
            else if (string.Equals(linkTarget, "_parent", StringComparison.OrdinalIgnoreCase))
            {
                Session?.SwitchToParentFrame();
                var parentFrameId = Session?.GetCurrentFrameId();
                await _webView.WaitForFrameDocumentReadyAsync(parentFrameId, readyBudget).ConfigureAwait(false);
            }
        }

        private async Task RunAtomClickWithClassification(string elementId)
        {
            var clickRes = await _webView.CallFunction(Atoms.CLICK, $"{{\"{Session.GetElementKey()}\":\"{elementId}\"}}", Session?.GetCurrentFrameId(), true, false, default).ConfigureAwait(false);
            var clickValue = JsonValueHelper.AsJsonNode(clickRes?.Result?.Value);
            var clickRaw = ResultValueConverter.ToWebBrowserException(clickValue);
            if (clickRaw is WebBrowserException clickEx)
            {
                if (!IsExecutionContextLostException(clickEx))
                    TuneAtomClickInteractableClassification(clickEx);
                throw clickEx;
            }

            if (clickRaw != null)
                throw clickRaw;
        }

        public async Task<string> ClickElement(string elementId)
        {
            if (_ZuChromeDriver != null)
                await _ZuChromeDriver.CheckConnected().ConfigureAwait(false);
            var tagName = await _elementUtils.GetElementTagName(elementId).ConfigureAwait(false);
            if (tagName == "option")
            {
                bool isToggleable = await _elementUtils.IsOptionElementTogglable(elementId).ConfigureAwait(false);
                if (isToggleable)
                {
                    await _elementUtils.ToggleOptionElement(elementId).ConfigureAwait(false);
                    return "ToggleOptionElement";
                }
                else
                {
                    await _elementUtils.SetOptionElementSelected(elementId).ConfigureAwait(false);
                    return "SetOptionElementSelected";
                }
            }
            else
            {
                WebPoint location = await _elementUtils.GetElementClickableLocation(elementId).ConfigureAwait(false);
                if (location == null)
                {
                    if (await _elementUtils.IsElementDisplayed(elementId).ConfigureAwait(false))
                    {
                        var obstructedCenter = await _elementUtils.GetSyntheticClickViewportCenter(elementId).ConfigureAwait(false);
                        if (obstructedCenter == null && !IsSvgPrimitiveTag(tagName))
                            throw new WebBrowserException("Element is not visible on the current page view", "ElementNotInteractableException");
                        if (obstructedCenter != null)
                        {
                            var (clickable, message) = await _elementUtils.GetElementClickability(elementId, obstructedCenter).ConfigureAwait(false);
                            if (!clickable)
                                throw new ElementClickInterceptedException(message);
                        }
                    }

                    location = await _elementUtils.GetSyntheticClickViewportCenter(elementId).ConfigureAwait(false);
                }

                if (location == null && IsSvgPrimitiveTag(tagName))
                {
                    await _elementUtils.ScrollElementIntoView(elementId, cancellationToken: default).ConfigureAwait(false);
                    location = await _elementUtils.GetSyntheticClickViewportCenter(elementId).ConfigureAwait(false);
                    if (location != null)
                    {
                        await RunClickAtPointAsync(location).ConfigureAwait(false);
                        return "Click";
                    }

                    // CDP coords unavailable for SVG primitive; SVG elements have no HTMLElement.click().
                    await RunAtomClickWithClassification(elementId).ConfigureAwait(false);
                    return "Click";
                }

                if (location == null)
                    throw new WebBrowserException("Element is not visible on the current page view", "ElementNotInteractableException");

                try
                {
                    var useTargetNavigation = false;
                    string linkTarget = null;
                    if (tagName == "a")
                    {
                        linkTarget = await _elementUtils.GetElementAttribute(elementId, "target").ConfigureAwait(false);
                        useTargetNavigation = !string.IsNullOrEmpty(linkTarget)
                            && linkTarget is not "_self" and not "_blank" and not "_parent" and not "_top";
                    }

                    if (useTargetNavigation &&
                        await TryNavigateNamedTargetFrameAsync(elementId).ConfigureAwait(false))
                    {
                        await WaitForNamedTargetFrameReadyAsync(elementId).ConfigureAwait(false);
                        Session.MousePosition = new Point(location.X, location.Y);
                        return "Click";
                    }

                    if (tagName == "a"
                        && !string.IsNullOrEmpty(linkTarget)
                        && (linkTarget.Equals("_top", StringComparison.OrdinalIgnoreCase)
                            || linkTarget.Equals("_parent", StringComparison.OrdinalIgnoreCase)))
                    {
                        await RunNativeElementClickAsync(elementId).ConfigureAwait(false);
                        await CompleteBrowsingContextChangeAfterLinkClickAsync(linkTarget).ConfigureAwait(false);
                        Session.MousePosition = new Point(location.X, location.Y);
                        return "Click";
                    }

                    await RunElementClickAsync(elementId, location, tagName).ConfigureAwait(false);
                    await CompleteBrowsingContextChangeAfterLinkClickAsync(linkTarget).ConfigureAwait(false);
                    return "Click";
                }
                catch (Exception ex) when (IsExecutionContextLostException(ex) || IsStaleElementReferenceException(ex))
                {
                    await RunClickAtPointAsync(location).ConfigureAwait(false);
                    return "Click";
                }
            }
        }

        public async Task<WebPoint> GetElementLocation(string elementId, CancellationToken cancellationToken = default)
        {
            var res = await _webView.CallFunction(Atoms.GET_LOCATION, $"{{\"{Session.GetElementKey()}\":\"{elementId}\"}}", _ZuChromeDriver.Session.GetCurrentFrameId(), cancellationToken: cancellationToken).ConfigureAwait(false);
            return ResultValueConverter.ToWebPoint(res?.Result?.Value);
        }

        internal Task<string> GetElementValueOfCssProperty(string elementId, string propertyName, CancellationToken cancellationToken = default)
        {
            return _elementUtils.GetElementEffectiveStyle(elementId, propertyName, cancellationToken);
        }

        public async Task<EvaluateCommandResponse> FocusElement(string elementId, CancellationToken cancellationToken = default)
        {
            var res = await _webView.CallFunction(focus_js.JsSource, $"{{\"{Session.GetElementKey()}\":\"{elementId}\"}}", _ZuChromeDriver.Session.GetCurrentFrameId(), true, false, cancellationToken).ConfigureAwait(false);
            return res;
        }

        public async Task<EvaluateCommandResponse> ClearElement(string elementId, CancellationToken cancellationToken = default)
        {
            var frameId = _ZuChromeDriver.Session?.GetCurrentFrameId();
            for (var attempt = 0; attempt < 8; attempt++)
            {
                if (!string.IsNullOrEmpty(frameId) && attempt > 0)
                    await _webView.WaitForFrameDocumentReadyAsync(frameId, TimeSpan.FromSeconds(2), cancellationToken).ConfigureAwait(false);

                try
                {
                    return await ClearElementOnceAsync(elementId, cancellationToken).ConfigureAwait(false);
                }
                catch (Exception ex) when (IsStaleElementReferenceException(ex) && attempt + 1 < 8)
                {
                    await Task.Delay(50, cancellationToken).ConfigureAwait(false);
                }
            }

            return await ClearElementOnceAsync(elementId, cancellationToken).ConfigureAwait(false);
        }

        private async Task<EvaluateCommandResponse> ClearElementOnceAsync(string elementId, CancellationToken cancellationToken)
        {
            var tagName = await _elementUtils.GetElementTagName(elementId, cancellationToken).ConfigureAwait(false);
            if (string.Equals(tagName, "input", StringComparison.OrdinalIgnoreCase))
            {
                var type = (await _elementUtils.GetElementAttribute(elementId, "type", cancellationToken).ConfigureAwait(false) ?? "").ToLowerInvariant();
                if (type == "color" || type == "date" || type == "datetime-local" || type == "time" || type == "month" || type == "week" || type == "range")
                {
                    var enabled = await _elementUtils.IsElementEnabled(elementId, cancellationToken).ConfigureAwait(false);
                    if (!enabled)
                        throw new WebBrowserException("Element must be user-editable in order to clear it.", "InvalidElementState");
                    var ro = await _elementUtils.GetElementAttribute(elementId, "readonly", cancellationToken).ConfigureAwait(false);
                    if (!string.IsNullOrEmpty(ro))
                        throw new WebBrowserException("Element must be user-editable in order to clear it.", "InvalidElementState");

                    const string clearHtml5InputValue = @"function(el){
  if (!el || el.tagName !== 'INPUT') return;
  var t = (el.type || '').toLowerCase();
  if (t === 'color') el.value = '#000000';
  else if (t === 'range') {
    var min = parseFloat(el.min); if (isNaN(min)) min = 0;
    var max = parseFloat(el.max); if (isNaN(max)) max = 100;
    el.value = String((min +max) / 2);
  } else if (t === 'date' || t === 'time' || t === 'datetime-local' || t === 'month' || t === 'week') el.value = '';
}";
                    var res = await _webView.CallFunction(clearHtml5InputValue, $"{{\"{Session.GetElementKey()}\":\"{elementId}\"}}", _ZuChromeDriver.Session.GetCurrentFrameId(), true, false, cancellationToken).ConfigureAwait(false);
                    var errNode = JsonValueHelper.AsJsonNode(res?.Result?.Value);
                    var exception = ResultValueConverter.ToWebBrowserException(errNode);
                    if (exception != null)
                        throw exception;
                    return res;
                }
            }

            var res2 = await _webView.CallFunction(Atoms.CLEAR, $"{{\"{Session.GetElementKey()}\":\"{elementId}\"}}", _ZuChromeDriver.Session.GetCurrentFrameId(), true, false, cancellationToken).ConfigureAwait(false);
            var err = JsonValueHelper.AsJsonNode(res2?.Result?.Value);
            var ex = ResultValueConverter.ToWebBrowserException(err);
            if (ex != null)
                throw ex;
            return res2;
        }

        public async Task<EvaluateCommandResponse> SubmitElement(string elementId, CancellationToken cancellationToken = default)
        {
            var res = await _webView.CallFunction(Atoms.SUBMIT, $"{{\"{Session.GetElementKey()}\":\"{elementId}\"}}", _ZuChromeDriver.Session.GetCurrentFrameId(), true, false, cancellationToken).ConfigureAwait(false);
            var err = JsonValueHelper.AsJsonNode(res?.Result?.Value);
            var ex = ResultValueConverter.ToWebBrowserException(err);
            if (ex != null)
                throw ex;
            return res;
        }

        public async Task<string> SendKeysToElement(string elementId, string keys, CancellationToken cancellationToken = default)
        {
            var isInput = await _elementUtils.IsElementAttributeEqualToIgnoreCase(elementId, "tagName", "input", cancellationToken).ConfigureAwait(false);
            var isFile = await _elementUtils.IsElementAttributeEqualToIgnoreCase(elementId, "type", "file", cancellationToken).ConfigureAwait(false);
            if (isInput && isFile)
            {
                bool multiple = await _elementUtils.IsElementAttributeEqualToIgnoreCase(elementId, "multiple", "true", cancellationToken).ConfigureAwait(false);
                return await _webView.SetFileInputFilesAsync(elementId, keys, append: multiple, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                var implicitWait = Session.ImplicitWait;
                var deadline = implicitWait == default ? DateTime.UtcNow : DateTime.UtcNow.Add(implicitWait);
                bool isDisplayed;
                bool isFocused;
                const int interactabilityPollTimeoutMs = 2000;
                while (true)
                {
                    isDisplayed = await _elementUtils.IsElementDisplayed(elementId, cancellationToken, interactabilityPollTimeoutMs).ConfigureAwait(false);
                    isFocused = await _elementUtils.IsElementFocused(elementId, cancellationToken, interactabilityPollTimeoutMs).ConfigureAwait(false);
                    if (isDisplayed || isFocused)
                        break;
                    if (implicitWait == default || DateTime.UtcNow >= deadline)
                    {
                        throw new WebBrowserException("Element is not displayed or focused", "ElementNotInteractableException");
                    }

                    await Task.Delay(100, cancellationToken).ConfigureAwait(false);
                }

                bool isEnabled = await _elementUtils.IsElementEnabled(elementId, cancellationToken).ConfigureAwait(false);
                if (!isEnabled)
                    throw new InvalidElementStateException("Element is not enabled");

                var targetElementId = elementId;
                var isTextControl = await IsTextControlTypeAsync(elementId, cancellationToken).ConfigureAwait(false);
                var isContentEditable = await IsContentEditableAsync(elementId, cancellationToken).ConfigureAwait(false);
                var wasPreviouslyFocused = isFocused;
                if (isContentEditable && !isTextControl)
                {
                    targetElementId = await PrepareContentEditableForKeysAsync(elementId, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    if (!isFocused)
                    {
                        await FocusElement(elementId, cancellationToken).ConfigureAwait(false);
                        isFocused = true;
                    }

                    // Chromedriver element_commands.cc: setSelectionRange only when newly focused.
                    if (isTextControl && !wasPreviouslyFocused &&
                        await SupportsSelectionRangeAsync(elementId, cancellationToken).ConfigureAwait(false))
                        await MoveTextInputCaretToEndAsync(elementId, cancellationToken).ConfigureAwait(false);
                }

                await _webView.DispatchKeyEvents(keys, cancellationToken).ConfigureAwait(false);
                if (Session.Frames.Count > 0)
                {
                    Session.StickyModifiers = 0;
                    await _webView.ReleasePhysicalModifiersAsync(cancellationToken).ConfigureAwait(false);
                }
                return "ok";
            }
        }

        private static readonly HashSet<string> TextControlInputTypes = new(StringComparer.OrdinalIgnoreCase)
        {
            "text", "password", "email", "number", "search", "tel", "url",
        };

        private async Task<bool> IsTextControlTypeAsync(string elementId, CancellationToken cancellationToken)
        {
            if (await _elementUtils.IsElementAttributeEqualToIgnoreCase(elementId, "tagName", "textarea", cancellationToken).ConfigureAwait(false))
                return true;
            if (!await _elementUtils.IsElementAttributeEqualToIgnoreCase(elementId, "tagName", "input", cancellationToken).ConfigureAwait(false))
                return false;
            var type = (await _elementUtils.GetElementAttribute(elementId, "type", cancellationToken).ConfigureAwait(false) ?? "text").ToLowerInvariant();
            return TextControlInputTypes.Contains(type);
        }

        private async Task<bool> IsContentEditableAsync(string elementId, CancellationToken cancellationToken)
        {
            const string script = "function(element) { return !!(element && element.isContentEditable); }";
            var res = await _webView.CallFunction(script, $"{{\"{Session.GetElementKey()}\":\"{elementId}\"}}", Session.GetCurrentFrameId(), true, false, cancellationToken).ConfigureAwait(false);
            var value = JsonValueHelper.AsJsonNode(res?.Result?.Value);
            var ex = ResultValueConverter.ToWebBrowserException(value);
            if (ex != null)
                throw ex;
            return JsonValueHelper.AsJsonNode(res?.Result?.Value)?["value"]?.GetValue<bool>() == true;
        }

        /// <summary>Chromedriver parity: focus top contentEditable host and place caret at end before SendKeys.</summary>
        private async Task<string> PrepareContentEditableForKeysAsync(string elementId, CancellationToken cancellationToken)
        {
            const string script = @"function(element) {
  while (element.parentElement && element.parentElement.isContentEditable) {
    element = element.parentElement;
  }
  var range = document.createRange();
  range.selectNodeContents(element);
  range.collapse(false);
  var sel = window.getSelection();
  sel.removeAllRanges();
  sel.addRange(range);
  element.focus();
  return element;
}";
            var res = await _webView.CallFunction(script, $"{{\"{Session.GetElementKey()}\":\"{elementId}\"}}", Session.GetCurrentFrameId(), true, false, cancellationToken).ConfigureAwait(false);
            var value = JsonValueHelper.AsJsonNode(res?.Result?.Value);
            var ex = ResultValueConverter.ToWebBrowserException(value);
            if (ex != null)
                throw ex;
            var topId = ResultValueConverter.ToElementId(res?.Result?.Value, Session.GetElementKey());
            return string.IsNullOrEmpty(topId) ? elementId : topId;
        }

        private async Task<bool> SupportsSelectionRangeAsync(string elementId, CancellationToken cancellationToken)
        {
            if (await _elementUtils.IsElementAttributeEqualToIgnoreCase(elementId, "tagName", "textarea", cancellationToken).ConfigureAwait(false))
                return true;
            if (!await _elementUtils.IsElementAttributeEqualToIgnoreCase(elementId, "tagName", "input", cancellationToken).ConfigureAwait(false))
                return false;
            var type = (await _elementUtils.GetElementAttribute(elementId, "type", cancellationToken).ConfigureAwait(false) ?? "").ToLowerInvariant();
            if (type is "email" or "number" or "date" or "datetime-local" or "month" or "week" or "time" or "color" or "range")
                return false;
            return type is "" or "text" or "password" or "search" or "tel" or "url";
        }

        private async Task MoveTextInputCaretToEndAsync(string elementId, CancellationToken cancellationToken)
        {
            const string script = "function(elem) { elem.setSelectionRange(elem.value.length, elem.value.length); }";
            var res = await _webView.CallFunction(script, $"{{\"{Session.GetElementKey()}\":\"{elementId}\"}}", Session.GetCurrentFrameId(), true, false, cancellationToken).ConfigureAwait(false);
            var ex = ResultValueConverter.ToWebBrowserException(JsonValueHelper.AsJsonNode(res?.Result?.Value));
            if (ex != null)
                throw ex;
        }
    }
}
// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// This file is based on or incorporates material from the Chromium Projects, licensed under the BSD-style license. More info in THIRD-PARTY-NOTICES file.
using System.Text.Json;
using System.Text.Json.Nodes;
using Zu.Common;
using Zu.WebDriver.BasicTypes;
using Zu.ChromeDevTools;
using Zu.Chrome.DriverCore;

namespace Zu.WebDriver
{
    public class ElementUtils
    {
        public Session Session
        {
            get;
            private set;
        }

        public WebView WebView
        {
            get;
            private set;
        }

        public ElementUtils(WebView webView, Session session)
        {
            Session = session;
            WebView = webView;
        }

        public async Task<bool> VerifyElementClickable(string elementId, WebPoint location, CancellationToken cancellationToken = new CancellationToken())
        {
            return await VerifyElementClickable(elementId, location, Session?.GetCurrentFrameId() ?? "", cancellationToken).ConfigureAwait(false);
        }

        public async Task<bool> VerifyElementClickable(string elementId, WebPoint location, string frameId, CancellationToken cancellationToken = new CancellationToken())
        {
            var (clickable, _) = await GetElementClickability(elementId, location, frameId, cancellationToken).ConfigureAwait(false);
            return clickable;
        }

        public async Task<(bool Clickable, string Message)> GetElementClickability(string elementId, WebPoint location, CancellationToken cancellationToken = new CancellationToken())
        {
            return await GetElementClickability(elementId, location, Session?.GetCurrentFrameId() ?? "", cancellationToken).ConfigureAwait(false);
        }

        public async Task<(bool Clickable, string Message)> GetElementClickability(string elementId, WebPoint location, string frameId, CancellationToken cancellationToken = new CancellationToken())
        {
            var res = await WebView.CallFunction(Atoms.IS_ELEMENT_CLICKABLE, $"{{\"{Session.GetElementKey()}\":\"{elementId}\"}}, {WebPointToJsonString(location)}", frameId, true, false, cancellationToken).ConfigureAwait(false);
            var value = JsonValueHelper.AsJsonObject(res?.Result?.Value)?["value"] as JsonObject;
            var clickable = (value?["clickable"] as JsonValue)?.GetValue<bool>() == true;
            var message = value?["message"]?.GetValue<string>() ?? "element click intercepted";
            return (clickable, message);
        }

        public string WebPointToJsonString(WebPoint point)
        {
            return $"{{ \"x\": {point.X}, \"y\": {point.Y} }}";
        }

        public string WebRectToJsonString(WebRect rect)
        {
            return $"{{\"left\": {rect.X}, \"top\": {rect.Y}, \"width\": {rect.Width}, \"height\": {rect.Height} }}";
        }

        public async Task<string> ScrollElementIntoView(string elementId, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ScrollElementIntoView(elementId, Session?.GetCurrentFrameId() ?? "", cancellationToken).ConfigureAwait(false);
        }

        public async Task<string> ScrollElementIntoView(string elementId, string frameId, CancellationToken cancellationToken = new CancellationToken())
        {
            var func = "function(elem) { return elem.scrollIntoView(); }";
            var res = await WebView.CallFunction(func, $"{{\"{Session.GetElementKey()}\":\"{elementId}\"}}", frameId, true, false, cancellationToken).ConfigureAwait(false);
            var value = JsonValueHelper.AsJsonNode(res?.Result?.Value);
            var exception = ResultValueConverter.ToWebBrowserException(value);
            if (exception != null)
                throw exception;
            return ResultValueConverter.AsString(res?.Result?.Value);
        }

        public async Task<WebPoint> ScrollElementRegionIntoViewHelper(string elementId, WebRect region, bool center = true, string clickableElementId = null, CancellationToken cancellationToken = new CancellationToken(), string frameId = null)
        {
            var evalFrame = frameId ?? Session?.GetCurrentFrameId() ?? "";
            await ScrollElementIntoView(elementId, evalFrame, cancellationToken).ConfigureAwait(false);
            var res = await WebView.CallFunction(Atoms.GET_LOCATION_IN_VIEW, $"{{\"{Session.GetElementKey()}\":\"{elementId}\"}}, {center.ToString().ToLower()}, {WebRectToJsonString(region)}", evalFrame, true, false, cancellationToken).ConfigureAwait(false);
            var location = ResultValueConverter.ToWebPoint(res?.Result?.Value);
            if (clickableElementId != null)
            {
                if (location == null)
                    return null;
                var middle = location.Offset(region.Width / 2, region.Height / 2);
                var isClickable = await VerifyElementClickable(clickableElementId, middle, evalFrame, cancellationToken).ConfigureAwait(false);
                if (!isClickable)
                    return null;
            }

            return location;
        }

        /// <summary>
        /// Chromedriver-style viewport point for CLICK when <see cref="GetElementClickableLocation"/> is null
        /// (e.g. opacity 0: not "displayed" but still receives events). Skips <c>IS_ELEMENT_CLICKABLE</c>.
        /// </summary>
        public async Task<WebPoint> GetSyntheticClickViewportCenter(string elementId, CancellationToken cancellationToken = default)
        {
            var rect = await GetElementRegion(elementId, cancellationToken).ConfigureAwait(false);
            if (rect == null || rect.Width <= 0 || rect.Height <= 0)
                return null;
            var locationInFrame = await ScrollElementRegionIntoView(elementId, rect, center: true, null, cancellationToken).ConfigureAwait(false);
            if (locationInFrame == null)
                return null;
            var center = locationInFrame.Offset(rect.Width / 2, rect.Height / 2);
            return await ApplyFrameChainViewportOffsetsAsync(center, cancellationToken).ConfigureAwait(false);
        }

        public Task<string> GetActiveElement(CancellationToken cancellationToken = new CancellationToken())
        {
            return GetActiveElement(cancellationToken, null);
        }

        public async Task<string> GetActiveElement(CancellationToken cancellationToken, int? millisecondsTimeout)
        {
            var func = "function() { return document.activeElement || document.body }";
            var frameId = Session == null ? "" : Session.GetCurrentFrameId();
            var res = await WebView.CallFunction(func, null, frameId, true, false, cancellationToken, millisecondsTimeout).ConfigureAwait(false);
            return ResultValueConverter.ToElementId(res?.Result?.Value, Session?.GetElementKey());
        //return res?.Result?.Value as JToken;
        }

        public Task<bool> IsElementFocused(string elementId, CancellationToken cancellationToken = new CancellationToken())
        {
            return IsElementFocused(elementId, cancellationToken, null);
        }

        public async Task<bool> IsElementFocused(string elementId, CancellationToken cancellationToken, int? millisecondsTimeout)
        {
            var activeElement = await GetActiveElement(cancellationToken, millisecondsTimeout).ConfigureAwait(false);
            return activeElement == elementId;
        }

        public async Task<string> GetElementAttribute(string elementId, string attributeName, CancellationToken cancellationToken = new CancellationToken())
        {
            var res = await WebView.CallFunction(Atoms.GET_ATTRIBUTE, $"{{\"{Session.GetElementKey()}\":\"{elementId}\"}}, \"{attributeName}\"", Session?.GetCurrentFrameId(), true, false, cancellationToken).ConfigureAwait(false);
            var value = JsonValueHelper.AsJsonNode(res?.Result?.Value);
            var exception = ResultValueConverter.ToWebBrowserException(value);
            if (exception != null)
                throw exception;
            return ResultValueConverter.AsString(res?.Result?.Value);
        }

        public async Task<string> GetElementProperty(string elementId, string propertyName, CancellationToken cancellationToken = new CancellationToken())
        {
            var func = "function(elem, prop) { try { var v = elem[prop]; if (v === undefined || v === null) return null; return String(v); } catch (e) { return null; } }";
            var propArg = JsonSerializer.Serialize(propertyName);
            var args = $"{{\"{Session.GetElementKey()}\":\"{elementId}\"}}, {propArg}";
            var res = await WebView.CallFunction(func, args, Session?.GetCurrentFrameId(), true, false, cancellationToken).ConfigureAwait(false);
            return ResultValueConverter.AsString(res?.Result?.Value);
        }

        public async Task<WebPoint> GetElementClickableLocation(string elementId, CancellationToken cancellationToken = new CancellationToken())
        {
            var targetElementId = elementId;
            var tagName = await GetElementTagName(targetElementId, cancellationToken).ConfigureAwait(false);
            if (tagName == "area")
            {
                var func = "function (element) {" + "  var map = element.parentElement;" + "  if (map.tagName.toLowerCase() != 'map')" + "    throw new Error('the area is not within a map');" + "  var mapName = map.getAttribute('name');" + "  if (mapName == null)" + "    throw new Error ('area\\'s parent map must have a name');" + "  mapName = '#' + mapName.toLowerCase();" + "  var images = document.getElementsByTagName('img');" + "  for (var i = 0; i < images.length; i++) {" + "    if (images[i].useMap.toLowerCase() == mapName)" + "      return images[i];" + "  }" + "  throw new Error('no img is found for the area');" + "}";
                var frameId = Session == null ? "" : Session.GetCurrentFrameId();
                var res = await WebView.CallFunction(func, $"{{\"{Session?.GetElementKey()}\":\"{targetElementId}\"}}", frameId, true, false, cancellationToken).ConfigureAwait(false);
                targetElementId = ResultValueConverter.ToElementId(res?.Result?.Value, Session?.GetElementKey());
            //return ResultValueConverter.ToWebPoint(res?.Result?.Value);
            }

            await WaitElementDisplayedForClickAsync(targetElementId, cancellationToken).ConfigureAwait(false);

            var rect = await GetElementRegion(targetElementId, cancellationToken).ConfigureAwait(false);
            if (rect == null || rect.Width <= 0 || rect.Height <= 0)
                throw new WebBrowserException("element has zero size", "ElementNotInteractableException");

            var location = await ScrollElementRegionIntoView(targetElementId, rect, true, elementId, cancellationToken).ConfigureAwait(false);
            if (location == null)
                return null;
            var center = location.Offset(rect.Width / 2, rect.Height / 2);
            return await ApplyFrameChainViewportOffsetsAsync(center, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>Chromedriver <c>WaitElementIsDisplayed</c> for click (<c>ignore_opacity=true</c>).</summary>
        public async Task WaitElementDisplayedForClickAsync(string elementId, CancellationToken cancellationToken = default)
        {
            var implicitWait = Session?.ImplicitWait ?? default;
            var deadline = implicitWait == default ? DateTime.UtcNow : DateTime.UtcNow.Add(implicitWait);
            while (true)
            {
                if (await IsElementDisplayed(elementId, ignoreOpacity: true, cancellationToken).ConfigureAwait(false))
                    return;
                if (implicitWait == default || DateTime.UtcNow >= deadline)
                    throw new WebBrowserException("Element is not visible on the current page view", "ElementNotInteractableException");
                await Task.Delay(50, cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// <see cref="ChromeDevTools.Input.InputAdapter.DispatchMouseEvent"/> coordinates are in the top-level viewport.
        /// Atoms return positions in the current frame's layout viewport; walk <see cref="Session.Frames"/> (deepest-first)
        /// and add each ancestor iframe's <c>getBoundingClientRect()</c> in its parent's document.
        /// </summary>
        private async Task<WebPoint> ApplyFrameChainViewportOffsetsAsync(WebPoint pointInCurrentFrame, CancellationToken cancellationToken)
        {
            if (Session?.Frames == null || !Session.Frames.Any())
                return pointInCurrentFrame;

            var acc = pointInCurrentFrame;
            var script = "function(id) {" +
                " id = String(id);" +
                " var el = document.evaluate(\"//*[@cd_frame_id_='\" + id + \"']\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;" +
                " if (!el) return { status: 0, value: { x: 0, y: 0 } };" +
                " var r = el.getBoundingClientRect();" +
                " return { status: 0, value: { x: r.left, y: r.top } };" +
                "}";
            foreach (var frame in Session.Frames)
            {
                var ownerDocFrameId = string.IsNullOrEmpty(frame.ParentFrameId) ? "" : frame.ParentFrameId;
                var argsJson = JsonSerializer.Serialize(new[] { frame.CromeFrameId }, ChromeDevToolsJsonSerializerOptions.Instance);
                var res = await WebView.CallFunction(script, argsJson, ownerDocFrameId, true, false, cancellationToken).ConfigureAwait(false);
                var delta = ResultValueConverter.ToWebPoint(res?.Result?.Value);
                if (delta != null)
                    acc = acc.Offset(delta.X, delta.Y);
            }

            return acc;
        }

        public async Task<WebRect> GetElementRegion(string elementId, CancellationToken cancellationToken = new CancellationToken())
        {
            //var expression = $"({get_element_region.JsSource}).apply(null, {{\"{Session.GetElementKey()}\":\"{elementId}\"}})";
            //var frameId = Session == null ? "" : Session.GetCurrentFrameId();
            //var res = await webView.EvaluateScript(expression, frameId, true, cancellationToken);
            var res = await WebView.CallFunction(get_element_region.JsSource, $"{{\"{Session.GetElementKey()}\":\"{elementId}\"}}", Session?.GetCurrentFrameId(), true, false, cancellationToken).ConfigureAwait(false);
            var value = JsonValueHelper.AsJsonNode(res?.Result?.Value);
            var exception = ResultValueConverter.ToWebBrowserException(value);
            if (exception != null)
                throw exception;
            return ResultValueConverter.ToWebRect(res?.Result?.Value);
        }

        public async Task<string> GetElementTagName(string elementId, CancellationToken cancellationToken = new CancellationToken())
        {
            var func = "function(elem) { return elem.tagName.toLowerCase(); }";
            var res = await WebView.CallFunction(func, $"{{\"{Session.GetElementKey()}\":\"{elementId}\"}}", Session?.GetCurrentFrameId(), true, false, cancellationToken).ConfigureAwait(false);
            var value = JsonValueHelper.AsJsonNode(res?.Result?.Value);
            var exception = ResultValueConverter.ToWebBrowserException(value);
            if (exception != null)
                throw exception;
            return ResultValueConverter.AsString(res?.Result?.Value);
        }

        public async Task<string> GetElementText(string elementId, CancellationToken cancellationToken = new CancellationToken())
        {
            var res = await WebView.CallFunction(Atoms.GET_TEXT, $"{{\"{Session.GetElementKey()}\":\"{elementId}\"}}", Session?.GetCurrentFrameId(), true, false, cancellationToken).ConfigureAwait(false);
            var value = JsonValueHelper.AsJsonNode(res?.Result?.Value);
            var exception = ResultValueConverter.ToWebBrowserException(value);
            if (exception != null)
                throw exception;
            return ResultValueConverter.AsString(res?.Result?.Value);
        }

        public async Task<WebSize> GetElementSize(string elementId, CancellationToken cancellationToken = new CancellationToken())
        {
            var res = await WebView.CallFunction(Atoms.GET_SIZE, $"{{\"{Session.GetElementKey()}\":\"{elementId}\"}}", Session?.GetCurrentFrameId(), true, false, cancellationToken).ConfigureAwait(false);
            var value = JsonValueHelper.AsJsonNode(res?.Result?.Value);
            var exception = ResultValueConverter.ToWebBrowserException(value);
            if (exception != null)
                throw exception;
            return ResultValueConverter.ToWebSize(res?.Result?.Value);
        }

        public Task<bool> IsElementDisplayed(string elementId, CancellationToken cancellationToken = new CancellationToken())
        {
            return IsElementDisplayed(elementId, false, cancellationToken, null);
        }

        public Task<bool> IsElementDisplayed(string elementId, CancellationToken cancellationToken, int? millisecondsTimeout)
        {
            return IsElementDisplayed(elementId, false, cancellationToken, millisecondsTimeout);
        }

        public async Task<bool> IsElementDisplayed(string elementId, bool ignoreOpacity, CancellationToken cancellationToken = default, int? millisecondsTimeout = null)
        {
            var args = ignoreOpacity
                ? $"{{\"{Session.GetElementKey()}\":\"{elementId}\"}}, true"
                : $"{{\"{Session.GetElementKey()}\":\"{elementId}\"}}";
            var res = await WebView.CallFunction(Atoms.IS_DISPLAYED, args, Session?.GetCurrentFrameId(), true, false, cancellationToken, millisecondsTimeout).ConfigureAwait(false);
            var value = JsonValueHelper.AsJsonNode(res?.Result?.Value);
            var exception = ResultValueConverter.ToWebBrowserException(value);
            if (exception != null)
                throw exception;
            return (JsonValueHelper.AsJsonObject(res?.Result?.Value)?["value"] as JsonValue)?.GetValue<bool>() == true;
        }

        public async Task<bool> IsElementEnabled(string elementId, CancellationToken cancellationToken = new CancellationToken())
        {
            var res = await WebView.CallFunction(Atoms.IS_ENABLED, $"{{\"{Session.GetElementKey()}\":\"{elementId}\"}}", Session?.GetCurrentFrameId(), true, false, cancellationToken).ConfigureAwait(false);
            var value = JsonValueHelper.AsJsonNode(res?.Result?.Value);
            var exception = ResultValueConverter.ToWebBrowserException(value);
            if (exception != null)
                throw exception;
            return ResultValueConverter.ToBool(res?.Result?.Value);
        }

        public async Task<bool> IsOptionElementSelected(string elementId, CancellationToken cancellationToken = new CancellationToken())
        {
            var res = await WebView.CallFunction(Atoms.IS_SELECTED, $"{{\"{Session.GetElementKey()}\":\"{elementId}\"}}", Session?.GetCurrentFrameId(), true, false, cancellationToken).ConfigureAwait(false);
            var value = JsonValueHelper.AsJsonNode(res?.Result?.Value);
            var exception = ResultValueConverter.ToWebBrowserException(value);
            if (exception != null)
                throw exception;
            return ResultValueConverter.ToBool(res?.Result?.Value);
        }

        public async Task<bool> IsOptionElementTogglable(string elementId, CancellationToken cancellationToken = new CancellationToken())
        {
            //var expression = $"({is_option_element_toggleable.JsSource}).apply(null, {{\"{Session.GetElementKey()}\":\"{elementId}\"}})";
            //var frameId = Session == null ? "" : Session.GetCurrentFrameId();
            //var res = await webView.EvaluateScript(expression, frameId, true, cancellationToken);
            var res = await WebView.CallFunction(is_option_element_toggleable.JsSource, $"{{\"{Session.GetElementKey()}\":\"{elementId}\"}}", Session?.GetCurrentFrameId(), true, false, cancellationToken).ConfigureAwait(false);
            var value = JsonValueHelper.AsJsonNode(res?.Result?.Value);
            var exception = ResultValueConverter.ToWebBrowserException(value);
            if (exception != null)
                throw exception;
            return ResultValueConverter.ToBool(res?.Result?.Value);
        }

        public async Task<bool> SetOptionElementSelected(string elementId, bool selected = true, CancellationToken cancellationToken = new CancellationToken())
        {
            var res = await WebView.CallFunction(Atoms.CLICK, $"{{\"{Session.GetElementKey()}\":\"{elementId}\"}}, {selected.ToString().ToLower()}", Session?.GetCurrentFrameId(), true, false, cancellationToken).ConfigureAwait(false);
            var value = JsonValueHelper.AsJsonNode(res?.Result?.Value);
            var exception = ResultValueConverter.ToWebBrowserException(value);
            if (exception != null)
                throw exception;
            return ResultValueConverter.ToBool(res?.Result?.Value);
        }

        public async Task ToggleOptionElement(string elementId, CancellationToken cancellationToken = new CancellationToken())
        {
            var isSelected = await IsOptionElementSelected(elementId, cancellationToken).ConfigureAwait(false);
            await SetOptionElementSelected(elementId, !isSelected).ConfigureAwait(false);
        }

        /// <summary>
        /// Mirrors <c>ScrollElementIntoView</c> in Chromedriver <c>element_util.cc</c>: use the element's
        /// full region with <c>GET_LOCATION_IN_VIEW</c> (<see cref="ScrollElementRegionIntoView"/> with
        /// <paramref name="center"/>: false). Chromedriver applies <paramref name="offset"/> only when
        /// computing a <c>WebPoint</c> for callers; it does not issue an extra <c>window.scrollBy</c>.
        /// </summary>
        public async Task ScrollElementIntoView(string elementId, WebPoint offset = null, CancellationToken cancellationToken = default)
        {
            var region = await GetElementRegion(elementId, cancellationToken).ConfigureAwait(false);
            await ScrollElementRegionIntoView(elementId, region, center: false, null, cancellationToken).ConfigureAwait(false);
            if (offset != null && (offset.X != 0 || offset.Y != 0))
            {
                // Chromedriver element_util ScrollElementIntoView: offset only adjusts the computed WebPoint for
                // callers that receive coordinates; it does not perform an extra viewport scroll.
            }
        }

        public async Task<WebPoint> ScrollElementRegionIntoView(string elementId, WebRect region, bool center, string clickableElementId = null, CancellationToken cancellationToken = new CancellationToken())
        {
            // Chromedriver element_util.cc ScrollElementRegionIntoView: scroll in current frame, then walk up
            // the frame chain so each iframe is scrolled into its parent viewport; location is top-level-relative.
            var regionOffset = new WebPoint(region.X, region.Y);
            var regionSize = region;
            var status = await ScrollElementRegionIntoViewHelper(elementId, region, center, clickableElementId, cancellationToken).ConfigureAwait(false);
            if (status == null)
                return null;
            regionOffset = status;

            if (Session?.Frames != null)
            {
                foreach (var frame in Session.Frames)
                {
                    var frameOwnerId = await ResolveFrameOwnerElementIdAsync(frame.ParentFrameId, frame.CromeFrameId, cancellationToken).ConfigureAwait(false);
                    if (string.IsNullOrEmpty(frameOwnerId))
                        continue;

                    var border = await GetElementBorder(frameOwnerId, frame.ParentFrameId, cancellationToken).ConfigureAwait(false);
                    if (border != null)
                        regionOffset = regionOffset.Offset(border.X, border.Y);

                    var ownerRegion = new WebRect(regionOffset.X, regionOffset.Y, regionSize.Width, regionSize.Height);
                    regionOffset = await ScrollElementRegionIntoViewHelper(frameOwnerId, ownerRegion, center, null, cancellationToken, frame.ParentFrameId).ConfigureAwait(false);
                    if (regionOffset == null)
                        return null;
                }
            }

            return regionOffset;
        }

        private async Task<string> ResolveFrameOwnerElementIdAsync(string parentFrameId, string chromeFrameId, CancellationToken cancellationToken)
        {
            const string script = "function(id) { id = String(id); var el = document.evaluate(\"//*[@cd_frame_id_='\" + id + \"']\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue; return el; }";
            var argsJson = JsonSerializer.Serialize(new[] { chromeFrameId }, ChromeDevToolsJsonSerializerOptions.Instance);
            var ownerDocFrameId = string.IsNullOrEmpty(parentFrameId) ? "" : parentFrameId;
            var res = await WebView.CallFunction(script, argsJson, ownerDocFrameId, true, false, cancellationToken).ConfigureAwait(false);
            return ResultValueConverter.ToElementId(res?.Result?.Value, Session?.GetElementKey());
        }

        /// <summary>
        /// Chromedriver-compatible location after scrolling the element into view (viewport coordinates for input dispatch).
        /// </summary>
        public async Task<WebPoint> GetLocationOnScreenOnceScrolledIntoView(string elementId, CancellationToken cancellationToken = default)
        {
            var region = await GetElementRegion(elementId, cancellationToken).ConfigureAwait(false);
            var locationInFrame = await ScrollElementRegionIntoView(elementId, region, center: false, null, cancellationToken).ConfigureAwait(false);
            if (locationInFrame == null)
                throw new WebBrowserException("Element is not visible", "element not interactable");
            return locationInFrame;
        }

        public Task<WebPoint> GetElementBorder(string elementId, CancellationToken cancellationToken = new CancellationToken())
        {
            return GetElementBorder(elementId, Session?.GetCurrentFrameId() ?? "", cancellationToken);
        }

        public async Task<WebPoint> GetElementBorder(string elementId, string frameId, CancellationToken cancellationToken = new CancellationToken())
        {
            var borderLeftStr = await GetElementEffectiveStyle(elementId, "border-left-width", frameId, cancellationToken).ConfigureAwait(false);
            var borderTopStr = await GetElementEffectiveStyle(elementId, "border-top-width", frameId, cancellationToken).ConfigureAwait(false);
            if (int.TryParse(borderLeftStr, out int x) && int.TryParse(borderTopStr, out int y))
            {
                return new WebPoint(x, y);
            }

            return null;
        }

        public Task<string> GetElementEffectiveStyle(string elementId, string property, CancellationToken cancellationToken = new CancellationToken())
        {
            return GetElementEffectiveStyle(elementId, property, Session?.GetCurrentFrameId() ?? "", cancellationToken);
        }

        public async Task<string> GetElementEffectiveStyle(string elementId, string property, string frameId, CancellationToken cancellationToken = new CancellationToken())
        {
            var res = await WebView.CallFunction(Atoms.GET_EFFECTIVE_STYLE, $"{{\"{Session.GetElementKey()}\":\"{elementId}\"}}, \"{property}\"", frameId, true, false, cancellationToken).ConfigureAwait(false);
            var value = JsonValueHelper.AsJsonNode(res?.Result?.Value);
            var exception = ResultValueConverter.ToWebBrowserException(value);
            if (exception != null)
                throw exception;
            return ResultValueConverter.AsString(res?.Result?.Value);
        }

        public async Task<bool> IsElementAttributeEqualToIgnoreCase(string elementId, string attributeName, string attributeValue, CancellationToken cancellationToken = new CancellationToken())
        {
            var attr = await GetElementAttribute(elementId, attributeName, cancellationToken).ConfigureAwait(false);
            return string.Equals(attr, attributeValue, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
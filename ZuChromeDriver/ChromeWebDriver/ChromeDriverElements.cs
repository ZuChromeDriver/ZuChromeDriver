// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
using System.Text.Json;
using System.Text.Json.Nodes;
using Zu.Chrome;
using Zu.WebDriver;
using Zu.WebDriver.AsyncInteractions;
using Zu.WebDriver.BasicTypes;

namespace Zu.ChromeWebDriver
{
    public class ChromeDriverElements : IElements
    {
        private IChromeDriver _ZuChromeDriver;
        public ChromeDriverElements(IChromeDriver ZuChromeDriver)
        {
            _ZuChromeDriver = ZuChromeDriver;
        }

        public async Task<string> ClearElement(string elementId, CancellationToken cancellationToken)
        {
            var res = await _ZuChromeDriver.ElementCommands.ClearElement(elementId, cancellationToken).ConfigureAwait(false);
            return "ok";
        }

        public Task Click(string elementId, CancellationToken cancellationToken = default)
        {
            return _ZuChromeDriver.ElementCommands.ClickElement(elementId);
        }

        public async Task<JsonNode> FindElement(string strategy, string expr, string startNode, string notElementId, TimeSpan timeout, CancellationToken cancellationToken = default)
        {
            try
            {
                JsonNode res = null;
                var waitEnd = default (DateTime);
                var nowTime = DateTime.Now;
                while (true)
                {
                    try
                    {
                        res = await _ZuChromeDriver.WindowCommands.FindElement(strategy, expr, startNode, cancellationToken).ConfigureAwait(false);
                    }
                    catch (Exception ex) when (IsNoSuchElement(DriverCoreExceptionMapper.MapException(ex)))
                    {
                        res = null;
                    }

                    if (!ResultValueConverter.ValueIsNull(res))
                    {
                        var elId = GetElementFromResponse(res);
                        if (string.IsNullOrEmpty(elId))
                        {
                            res = null;
                        }
                        else if (notElementId == null)
                        {
                            break;
                        }
                        else if (elId != notElementId)
                        {
                            break;
                        }
                        else { res = null; }
                    }

                    if (waitEnd == default)
                    {
                        var implicitWait = timeout;
                        if (implicitWait == default)
                            implicitWait = await _ZuChromeDriver.Options.Timeouts.GetImplicitWait().ConfigureAwait(false);
                        if (implicitWait == default)
                            break;
                        waitEnd = nowTime + implicitWait;
                    }

                    if (DateTime.Now > waitEnd)
                        break;
                    await Task.Delay(50).ConfigureAwait(false);
                }

                if (ResultValueConverter.ValueIsNull(res) || string.IsNullOrEmpty(GetElementFromResponse(res)))
                    throw new WebBrowserException($"Element not found by {strategy} = {expr}", "no such element");
                return res;
            }
            catch (Exception ex)
            {
                throw DriverCoreExceptionMapper.MapException(ex);
            }
        //var res = await ZuChromeDriver.WindowCommands.FindElement(strategy, expr, startNode, cancellationToken);
        //if (ResultValueConverter.ValueIsNull(res)) 
        //{
        //    var implicitWait = await ZuChromeDriver.Options.Timeouts.GetImplicitWait();
        //    if (implicitWait != default(TimeSpan))
        //    {
        //        var waitEnd = DateTime.Now + implicitWait;
        //        while (ResultValueConverter.ValueIsNull(res) && DateTime.Now < waitEnd)
        //        {
        //            Thread.Sleep(50);
        //            res = await ZuChromeDriver.WindowCommands.FindElement(strategy, expr, startNode, cancellationToken = default(CancellationToken));
        //        }
        //    }
        //}
        //if (ResultValueConverter.ValueIsNull(res)) throw new WebBrowserException($"Element not found by {strategy} = {expr}", "no such element");
        //return res;
        }

        public static string GetElementFromResponse(JsonNode response)
        {
            if (response == null)
                return null;
            var json = WebDriverJsonHelper.UnwrapWebDriverValueContainer(response);
            if (json == null)
                return null;
            if (json is JsonValue jv)
            {
                if (jv.GetValueKind() == JsonValueKind.Null)
                    return null;
                return jv.GetValue<string>();
            }

            var id = (json["element-6066-11e4-a52e-4f735466cecf"] as JsonValue)?.GetValue<string>();
            if (id == null && json["ELEMENT"] is JsonValue ev)
                id = ev.GetValue<string>();
            return id;
        }

        public async Task<JsonNode> FindElements(string strategy, string expr, string startNode, string notElementId, TimeSpan timeout, CancellationToken cancellationToken = default)
        {
            try
            {
                JsonNode res = null;
                var waitEnd = default (DateTime);
                var nowTime = DateTime.Now;
                while (true)
                {
                    res = await _ZuChromeDriver.WindowCommands.FindElements(strategy, expr, startNode, cancellationToken).ConfigureAwait(false);
                    var satisfied = false;
                    if (GetElementsFromResponse(res)?.Any(id => !string.IsNullOrEmpty(id)) == true)
                    {
                        if (notElementId == null)
                            satisfied = true;
                        else
                        {
                            var elId = GetElementsFromResponse(res);
                            var first = elId?.FirstOrDefault();
                            if (!string.IsNullOrEmpty(first) && first != notElementId)
                                satisfied = true;
                        }
                    }

                    if (satisfied)
                        break;

                    if (waitEnd == default)
                    {
                        var implicitWait = timeout;
                        if (implicitWait == default)
                            implicitWait = await _ZuChromeDriver.Options.Timeouts.GetImplicitWait().ConfigureAwait(false);
                        if (implicitWait == default)
                            break;
                        waitEnd = nowTime + implicitWait;
                    }

                    if (DateTime.Now > waitEnd)
                        break;
                    await Task.Delay(50).ConfigureAwait(false);
                }

                //if ((res as JsonArray)?.Any() != true) throw new WebBrowserException($"Elements not found by {strategy} = {expr}", "no such element");
                return res;
            }
            catch (Exception ex)
            {
                throw DriverCoreExceptionMapper.MapException(ex);
            }
        //var res = await ZuChromeDriver.WindowCommands.FindElements(strategy, expr, startNode, cancellationToken = default(CancellationToken));
        //if ((res as JsonArray)?.Any() != true)
        //{
        //    var implicitWait = await ZuChromeDriver.Options.Timeouts.GetImplicitWait();
        //    if (implicitWait != default(TimeSpan))
        //    {
        //        var waitEnd = DateTime.Now + implicitWait;
        //        while (((res as JsonArray)?.Any() != true) && DateTime.Now < waitEnd)
        //        {
        //            Thread.Sleep(50);
        //            res = await ZuChromeDriver.WindowCommands.FindElements(strategy, expr, startNode, cancellationToken = default(CancellationToken));
        //        }
        //    }
        //}
        //if (res == null) throw new WebBrowserException($"Element not found by {strategy} = {expr}", "no such element");
        //return res;
        ////return ZuChromeDriver.WindowCommands.FindElements(strategy, expr, startNode, cancellationToken);
        }

        private static bool IsNoSuchElement(Exception ex) =>
            ex is WebBrowserException wbe && string.Equals(wbe.Error, "no such element", StringComparison.Ordinal);

        static JsonArray GetElementsArray(JsonNode response)
        {
            if (response == null)
                return null;
            if (response is JsonArray arr)
                return arr;
            if (response is JsonObject)
                return WebDriverJsonHelper.UnwrapWebDriverValueContainer(response) as JsonArray;
            return null;
        }

        public static List<string> GetElementsFromResponse(JsonNode response)
        {
            var toReturn = new List<string>();
            var arr = GetElementsArray(response);
            if (arr == null)
                return toReturn;
            foreach (var item in arr)
                {
                    string id = null;
                    try
                    {
                        JsonNode json;
                        if (item is JsonValue jvv && jvv.GetValueKind() == JsonValueKind.String)
                            json = JsonNode.Parse(jvv.GetValue<string>());
                        else
                            json = item;
                        if (json is JsonObject)
                        {
                            id = (json["element-6066-11e4-a52e-4f735466cecf"] as JsonValue)?.GetValue<string>();
                            id ??= (json["ELEMENT"] as JsonValue)?.GetValue<string>();
                        }
                        else if (json is JsonValue jv2)
                        {
                            if (jv2.GetValueKind() != JsonValueKind.Null)
                                id = jv2.GetValue<string>();
                        }
                    }
                    catch
                    {
                    }

                    toReturn.Add(id);
                }

            return toReturn;
        }

        public Task<string> GetActiveElement(CancellationToken cancellationToken = default)
        {
            return _ZuChromeDriver.ElementUtils.GetActiveElement(cancellationToken);
        }

        public Task<string> GetElementAttribute(string elementId, string attrName, CancellationToken cancellationToken = default)
        {
            return _ZuChromeDriver.ElementUtils.GetElementAttribute(elementId, attrName, cancellationToken);
        }

        public Task<WebPoint> GetElementLocation(string elementId, CancellationToken cancellationToken = default)
        {
            return _ZuChromeDriver.ElementCommands.GetElementLocation(elementId, cancellationToken);
        }

        public async Task<string> GetElementProperty(string elementId, string propertyName, CancellationToken cancellationToken = default)
        {
            return await _ZuChromeDriver.ElementUtils.GetElementProperty(elementId, propertyName, cancellationToken).ConfigureAwait(false);
        }

        public Task<WebRect> GetElementRect(string elementId, CancellationToken cancellationToken = default)
        {
            return _ZuChromeDriver.ElementUtils.GetElementRegion(elementId, cancellationToken);
        }

        public Task<WebSize> GetElementSize(string elementId, CancellationToken cancellationToken = default)
        {
            return _ZuChromeDriver.ElementUtils.GetElementSize(elementId, cancellationToken);
        }

        public Task<string> GetElementTagName(string elementId, CancellationToken cancellationToken = default)
        {
            return _ZuChromeDriver.ElementUtils.GetElementTagName(elementId, cancellationToken);
        }

        public Task<string> GetElementText(string elementId, CancellationToken cancellationToken = default)
        {
            return _ZuChromeDriver.ElementUtils.GetElementText(elementId, cancellationToken);
        }

        public Task<string> GetElementValueOfCssProperty(string elementId, string propertyName, CancellationToken cancellationToken = default)
        {
            return _ZuChromeDriver.ElementCommands.GetElementValueOfCssProperty(elementId, propertyName, cancellationToken);
        }

        public Task<bool> IsElementDisplayed(string elementId, CancellationToken cancellationToken = default)
        {
            return _ZuChromeDriver.ElementUtils.IsElementDisplayed(elementId, cancellationToken);
        }

        public Task<bool> IsElementEnabled(string elementId, CancellationToken cancellationToken = default)
        {
            return _ZuChromeDriver.ElementUtils.IsElementEnabled(elementId, cancellationToken);
        }

        public Task<bool> IsElementSelected(string elementId, CancellationToken cancellationToken = default)
        {
            return _ZuChromeDriver.ElementUtils.IsOptionElementSelected(elementId, cancellationToken);
        }

        public Task<string> SendKeysToElement(string elementId, string value, CancellationToken cancellationToken = default)
        {
            return _ZuChromeDriver.ElementCommands.SendKeysToElement(elementId, value);
        }

        public async Task<string> SubmitElement(string elementId, CancellationToken cancellationToken = default)
        {
            var res = await _ZuChromeDriver.ElementCommands.SubmitElement(elementId, cancellationToken).ConfigureAwait(false);
            return "ok";
        }

#region FindElement variants
        public Task<JsonNode> FindElement(string strategy, string expr, CancellationToken cancellationToken = default)
        {
            return FindElement(strategy, expr, null, null, default (TimeSpan), cancellationToken);
        }

        public Task<JsonNode> FindElement(string strategy, string expr, TimeSpan timeout, CancellationToken cancellationToken = default)
        {
            return FindElement(strategy, expr, null, null, timeout, cancellationToken);
        }

        public Task<JsonNode> FindElement(string strategy, string expr, int timeoutMs, CancellationToken cancellationToken = default)
        {
            return FindElement(strategy, expr, null, null, TimeSpan.FromMilliseconds(timeoutMs), cancellationToken);
        }

        public Task<JsonNode> FindElement(string strategy, string expr, string startNode, CancellationToken cancellationToken = default)
        {
            return FindElement(strategy, expr, startNode, null, default (TimeSpan), cancellationToken);
        }

        public Task<JsonNode> FindElement(string strategy, string expr, string startNode, TimeSpan timeout, CancellationToken cancellationToken = default)
        {
            return FindElement(strategy, expr, startNode, null, timeout, cancellationToken);
        }

        public Task<JsonNode> FindElement(string strategy, string expr, string startNode, int timeoutMs, CancellationToken cancellationToken = default)
        {
            return FindElement(strategy, expr, startNode, null, TimeSpan.FromMilliseconds(timeoutMs), cancellationToken);
        }

        public Task<JsonNode> FindElement(string strategy, string expr, string startNode, string notElementId, CancellationToken cancellationToken = default)
        {
            return FindElement(strategy, expr, startNode, notElementId, default (TimeSpan), cancellationToken);
        }

        public Task<JsonNode> FindElement(string strategy, string expr, string startNode, string notElementId, int timeoutMs, CancellationToken cancellationToken = default)
        {
            return FindElement(strategy, expr, startNode, notElementId, TimeSpan.FromMilliseconds(timeoutMs), cancellationToken);
        }

        public Task<JsonNode> FindElements(string strategy, string expr, CancellationToken cancellationToken = default)
        {
            return FindElements(strategy, expr, null, null, default (TimeSpan), cancellationToken);
        }

        public Task<JsonNode> FindElements(string strategy, string expr, TimeSpan timeout, CancellationToken cancellationToken = default)
        {
            return FindElements(strategy, expr, null, null, timeout, cancellationToken);
        }

        public Task<JsonNode> FindElements(string strategy, string expr, int timeoutMs, CancellationToken cancellationToken = default)
        {
            return FindElements(strategy, expr, null, null, TimeSpan.FromMilliseconds(timeoutMs), cancellationToken);
        }

        public Task<JsonNode> FindElements(string strategy, string expr, string startNode, CancellationToken cancellationToken = default)
        {
            return FindElements(strategy, expr, startNode, null, default (TimeSpan), cancellationToken);
        }

        public Task<JsonNode> FindElements(string strategy, string expr, string startNode, TimeSpan timeout, CancellationToken cancellationToken = default)
        {
            return FindElements(strategy, expr, startNode, null, timeout, cancellationToken);
        }

        public Task<JsonNode> FindElements(string strategy, string expr, string startNode, int timeoutMs, CancellationToken cancellationToken = default)
        {
            return FindElements(strategy, expr, startNode, null, TimeSpan.FromMilliseconds(timeoutMs), cancellationToken);
        }

        public Task<JsonNode> FindElements(string strategy, string expr, string startNode, string notElementId, CancellationToken cancellationToken = default)
        {
            return FindElements(strategy, expr, startNode, notElementId, default (TimeSpan), cancellationToken);
        }

        public Task<JsonNode> FindElements(string strategy, string expr, string startNode, string notElementId, int timeoutMs, CancellationToken cancellationToken = default)
        {
            return FindElements(strategy, expr, startNode, notElementId, TimeSpan.FromMilliseconds(timeoutMs), cancellationToken);
        }
#endregion
    }
}
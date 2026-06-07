// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
using System.Collections;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Nodes;
using Zu.ChromeDevTools;
using Zu.Chrome;
using Zu.WebDriver;
using Zu.Common;
using Zu.WebDriver.BasicTypes;
using Zu.WebDriver.AsyncInteractions;

namespace Zu.ChromeWebDriver
{
    public class ChromeDriverJavaScriptExecutor : IJavaScriptExecutor
    {
        private IChromeDriver _ZuChromeDriver;
        public ChromeDriverJavaScriptExecutor(IChromeDriver ZuChromeDriver)
        {
            _ZuChromeDriver = ZuChromeDriver;
        }

        public async Task<object> ExecuteAsyncScript(string script, CancellationToken cancellationToken = default, params object[] args)
        {
            try
            {
                var res = await _ZuChromeDriver.WindowCommands.ExecuteAsyncScript(script, ArgsToStringList(args)).ConfigureAwait(false);
                var value = JsonValueHelper.AsJsonObject(res)?["value"];
                var payload = NormalizeNestedWebDriverEnvelope(value);
                var jo = JsonValueHelper.AsJsonObject(payload);
                var st = jo?["status"]?.ToString();
                if (st != null && st != "0")
                {
                    if (st == "17")
                        throw new WebBrowserException(jo["value"]?.ToString(), "WebDriverException") {Json = payload};
                    var exception = ResultValueConverter.ToWebBrowserException(payload);
                    if (exception != null)
                        throw exception;
                }

                return ParseExecuteScriptReturnValueInternal(JsonValueHelper.AsJsonObject(payload)?["value"]);
            }
            catch (CommandResponseException ex)
            {
                throw new WebBrowserException(ex.Message, "WebDriverException");
            }
        }

        /// <summary>
        /// CDP + call_function may produce chains like <c>{ status: 0, value: { status: 17, value: ... } }</c>.
        /// Peel outer OK envelopes until the inner WebDriver status/value pair is reached.
        /// </summary>
        private static JsonNode NormalizeNestedWebDriverEnvelope(JsonNode node)
        {
            var cur = node;
            for (var depth = 0; depth < 8 && cur is JsonObject o; depth++)
            {
                if (!o.TryGetPropertyValue("status", out var st) || st?.ToString() != "0")
                    break;
                if (!o.TryGetPropertyValue("value", out var inner) || inner is not JsonObject innerObj)
                    break;
                if (!innerObj.TryGetPropertyValue("status", out _))
                    break;
                cur = inner;
            }

            return cur;
        }

        internal ReadOnlyCollection<object> CreateListOfObjects(JsonArray array)
        {
            var res = new List<object>();
            foreach (var val in array)
            {
                if (val is JsonValue jv)
                    res.Add(UnwrapPrimitive(jv.GetValue<object>()));
                else if (val is JsonArray)
                    res.Add(CreateListOfObjects((JsonArray)val));
                else
                    res.Add(val);
            }

            return new ReadOnlyCollection<object>(res);
        }

        public async Task<object> ExecuteScript(string script, CancellationToken cancellationToken = default, params object[] args)
        {
            var res = await _ZuChromeDriver.WindowCommands.ExecuteScript(script, ArgsToStringList(args)).ConfigureAwait(false);
            var exception = ResultValueConverter.ToWebBrowserException(res);
            if (exception != null)
                throw exception;
            return ParseExecuteScriptReturnValueInternal(JsonValueHelper.AsJsonObject(res)?["value"]);
        }

        internal List<string> ArgsToStringList(object[] args)
        {
            return args.Select(v => ArgToString(v)).ToList();
        }

        internal string ArgToString(object arg)
        {
            if (arg == null)
                return "null";
            if (arg is bool)
                return (bool)arg ? "true" : "false";
            if (arg is float f)
                return f.ToString(CultureInfo.InvariantCulture);
            if (arg is double d)
                return d.ToString(CultureInfo.InvariantCulture);
            if (arg is decimal m)
                return m.ToString(CultureInfo.InvariantCulture);
            if (arg is string)
                return $"'{(string)arg}'";
            IDictionary dictionaryArg = arg as IDictionary;
            if (dictionaryArg != null)
            {
                List<string> stringList = [];
                foreach (DictionaryEntry kv in dictionaryArg)
                {
                    stringList.Add($"'{kv.Key}': {ArgToString(kv.Value)}");
                }

                return $"{{ {string.Join(", ", stringList)} }}";
            }

            if (arg is IDictionary<string, object>)
                return $"{{ {string.Join(", ", ((IDictionary<string, object>)arg).Select(v => ArgToString(v)))} }}";
            if (arg is KeyValuePair<string, object>)
            {
                var kv = (KeyValuePair<string, object>)arg;
                return $"{{ '{kv.Key}': {ArgToString(kv.Value)} }}";
            }

            IEnumerable enumerableArg = arg as IEnumerable;
            if (enumerableArg != null)
            {
                List<object> objectList = [.. enumerableArg];

                return $"[ {string.Join(", ", ArgsToStringList((objectList.ToArray())))} ]";
            }

            return arg.ToString();
        }

        private static object ParseExecuteScriptReturnValueInternal(JsonNode responseValue)
        {
            if (responseValue is JsonValue jv)
                return UnwrapPrimitive(jv.GetValue<object>());
            if (responseValue is JsonArray ja)
            {
                var res = new List<object>();
                foreach (var item in ja)
                {
                    res.Add(ParseExecuteScriptReturnValueInternal(item));
                }

                return res.ToArray();
            }
            else if (responseValue is JsonObject jo)
            {
                var res = new Dictionary<string, object>();
                foreach (var item in jo)
                {
                    res.Add(item.Key, ParseExecuteScriptReturnValueInternal(item.Value));
                }

                return res;
            }

            return responseValue;
        }

        /// <summary>
        /// Maps JSON primitives surfaced as <see cref="JsonElement"/> (common with newer STJ + CDP
        /// deserialization) to CLR types expected by WebDriver tests.
        /// </summary>
        private static object UnwrapPrimitive(object raw)
        {
            if (raw is JsonElement je)
                return ConvertJsonElement(je);
            return raw;
        }

        private static object ConvertJsonElement(JsonElement je)
        {
            switch (je.ValueKind)
            {
                case JsonValueKind.Object:
                case JsonValueKind.Array:
                    return ParseExecuteScriptReturnValueInternal(JsonNode.Parse(je.GetRawText()));
                case JsonValueKind.String:
                    return je.GetString();
                case JsonValueKind.Number:
                    if (je.TryGetInt64(out var l))
                        return l;
                    if (je.TryGetDouble(out var d))
                        return d;
                    return je.GetDecimal();
                case JsonValueKind.True:
                    return true;
                case JsonValueKind.False:
                    return false;
                case JsonValueKind.Null:
                case JsonValueKind.Undefined:
                    return null;
                default:
                    return null;
            }
        }
    }
}

// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Text.Json;
using System.Text.Json.Nodes;
using Zu.Chrome.DriverCore;
using Zu.Common;
using Zu.WebDriver.BasicTypes;

namespace Zu.WebDriver
{
    internal class ResultValueConverter
    {
        /// <summary>
        /// Chrome DevTools / CDP JSON often uses Number (double); integer coercion must tolerate both.
        /// </summary>
        private static int? JsonNumberAsInt(JsonNode node)
        {
            if (node is not JsonValue jv) return null;
            try
            {
                return jv.GetValue<int>();
            }
            catch (InvalidOperationException)
            {
                try
                {
                    return (int)Math.Round(jv.GetValue<double>());
                }
                catch (InvalidOperationException)
                {
                    return null;
                }
            }
        }

        internal static WebPoint ToWebPoint(object value)
        {
            var res = JsonValueHelper.AsJsonObject(value)?["value"];
            if (res == null) return null;
            // Some atoms return `[x, y]` instead of `{ x, y }` (e.g. SVG/viewport quirks for GET_LOCATION_IN_VIEW).
            if (res is JsonArray arr && arr.Count >= 2)
            {
                var x = JsonNumberAsInt(arr[0]);
                var y = JsonNumberAsInt(arr[1]);
                if (x != null && y != null) return new WebPoint(x.Value, y.Value);
            }
            else if (res is JsonObject obj)
            {
                var x = JsonNumberAsInt(obj["x"]);
                var y = JsonNumberAsInt(obj["y"]);
                if (x != null && y != null) return new WebPoint(x.Value, y.Value);
            }

            return null;
        }

        internal static WebSize ToWebSize(object value)
        {
            var res = JsonValueHelper.AsJsonObject(value)?["value"];
            if (res is JsonObject obj)
            {
                var width = JsonNumberAsInt(obj["width"]);
                var height = JsonNumberAsInt(obj["height"]);
                if (width != null && height != null) return new WebSize(width.Value, height.Value);
            }

            return null;
        }

        internal static WebRect ToWebRect(object value)
        {
            var res = JsonValueHelper.AsJsonObject(value)?["value"];
            if (res is JsonObject jo)
            {
                var x = JsonNumberAsInt(jo["x"]) ?? JsonNumberAsInt(jo["left"]);
                var y = JsonNumberAsInt(jo["y"]) ?? JsonNumberAsInt(jo["top"]);
                var width = JsonNumberAsInt(jo["width"]);
                var height = JsonNumberAsInt(jo["height"]);
                if (x != null && y != null && width != null && height != null) return new WebRect(x.Value, y.Value, width.Value, height.Value);
            }

            return null;
        }

        internal static bool ToBool(object value)
        {
            return (JsonValueHelper.AsJsonObject(value)?["value"] as JsonValue)?.GetValue<bool>() == true;
        }

        internal static bool ValueIsNull(JsonNode res)
        {
            if (res == null) return true;
            if (res is not JsonObject obj || !obj.TryGetPropertyValue("value", out var v) || v == null) return false;
            return v.GetValueKind() == JsonValueKind.Null;
        }

        internal static string AsString(object value)
        {
            return (JsonValueHelper.AsJsonObject(value)?["value"] as JsonValue)?.GetValue<string>()?.Replace("\n", "\r\n").Replace("\r\r", "\r");
        }

        internal static string ToElementId(object value, string elementKey = "ELEMENT")
        {
            var inner = JsonValueHelper.AsJsonObject(value)?["value"];
            if (inner is JsonObject elObj && elObj.TryGetPropertyValue(elementKey, out var idNode))
                return (idNode as JsonValue)?.GetValue<string>() ?? idNode?.ToString();
            return null;
        }

        internal static Exception ToWebBrowserException(JsonNode json)
        {
            var dce = AtomResultConverter.ToDriverCoreException(json);
            if (dce == null)
                return null;
            return new WebBrowserException(dce.Message)
            {
                Error = dce.Error,
                Json = dce.Json
            };
        }
    }
}

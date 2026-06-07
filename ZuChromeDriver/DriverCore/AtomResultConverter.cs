// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Text.Json.Nodes;

namespace Zu.Chrome.DriverCore
{
    internal static class AtomResultConverter
    {
        internal static DriverCoreException ToDriverCoreException(JsonNode json)
        {
            if (json is JsonArray)
                return null;
            var jo = json as JsonObject;
            var status = jo?["status"]?.ToString();
            if (status == "0")
                return null;
            var value = jo?["value"]?.ToString();
            var res = new DriverCoreException(value)
            {
                Json = json
            };
            if (value == null) { }
            else if (status == "10" && value == "element is not attached to the page document")
            {
                res.Error = "stale element reference";
            }
            else if (status == "7")
            {
                res.Error = "no such element";
            }
            else if (status == "13" && !string.IsNullOrEmpty(value) && value.EndsWith("is not defined"))
            {
                res.Error = "invalid operation";
            }
            else if (status == "32")
            {
                res.Error = "invalid selector";
            }
            else if (status == "17")
            {
                res.Error = "javascript error";
            }
            else if (status == "28")
            {
                res.Error = "WebDriverTimeoutException";
            }
            else if (status == "12")
            {
                res.Error = "InvalidElementState";
            }
            else
            {
                res.Error = "WebDriverException";
            }

            return res;
        }
    }
}

// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Text.Json;
using System.Text.Json.Nodes;

namespace Zu.WebDriver
{
    internal static class WebDriverJsonHelper
    {
        /// <summary>
        /// Mirrors Newtonsoft-era logic: if the node is a JSON string value, parse it; otherwise return ["value"].
        /// </summary>
        internal static JsonNode UnwrapWebDriverValueContainer(JsonNode response)
        {
            if (response == null)
                return null;
            if (response is JsonValue jv)
            {
                if (jv.TryGetValue<string>(out var s) && !string.IsNullOrEmpty(s))
                {
                    try
                    {
                        return JsonNode.Parse(s);
                    }
                    catch (JsonException)
                    {
                        return response;
                    }
                }

                return response;
            }

            return response["value"];
        }
    }
}

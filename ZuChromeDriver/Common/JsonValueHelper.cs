// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Text.Json;
using System.Text.Json.Nodes;
using Zu.ChromeDevTools;

namespace Zu.Common
{
    internal static class JsonValueHelper
    {
        internal static JsonNode AsJsonNode(object value)
        {
            if (value == null)
                return null;
            if (value is JsonNode node)
                return node;
            if (value is JsonElement el)
            {
                if (el.ValueKind is JsonValueKind.Null or JsonValueKind.Undefined)
                    return null;
                return JsonNode.Parse(el.GetRawText());
            }

            return JsonSerializer.SerializeToNode(value, value.GetType(), ChromeDevToolsJsonSerializerOptions.Instance);
        }

        internal static JsonObject AsJsonObject(object value) => AsJsonNode(value) as JsonObject;
    }
}

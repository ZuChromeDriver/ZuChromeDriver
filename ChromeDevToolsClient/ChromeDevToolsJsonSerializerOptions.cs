using System.Text.Json;
using System.Text.Json.Serialization;

namespace Zu.ChromeDevTools
{
    /// <summary>
    /// Serializer options for Chrome DevTools Protocol JSON (property names come from attributes).
    /// </summary>
    public static class ChromeDevToolsJsonSerializerOptions
    {
        public static JsonSerializerOptions Instance { get; } = new JsonSerializerOptions
        {
            PropertyNamingPolicy = null,
            DefaultIgnoreCondition = JsonIgnoreCondition.Never
        };
    }
}

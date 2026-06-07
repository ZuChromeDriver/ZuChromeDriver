using System.Text.Json.Nodes;

namespace Zu.Chrome.DevTools
{
    public class DevToolsEventData
    {
        public string EventName { get; set; }
        public JsonNode Data { get; set; }
    }
}

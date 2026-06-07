using System.Text.Json.Nodes;

namespace Zu.Chrome.DevTools
{
    public class DevToolsCommandResult
    {
        public int Id { get; set; }
        public JsonNode Result { get; set; }
        public string Error { get; set; }
    }
}

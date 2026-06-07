using System.Text.Json.Nodes;

namespace Zu.Chrome.DevTools
{
    public class DevToolsCommandData
    {
        public int Id { get; set; }
        public string BrowserId { get; set; }
        public string CommandName { get; set; }
        public JsonNode Params { get; set; }
        public int? MillisecondsTimeout { get; set; }

    }
}

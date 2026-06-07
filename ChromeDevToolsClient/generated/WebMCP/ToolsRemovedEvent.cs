namespace Zu.ChromeDevTools.WebMCP
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Event fired when tools are removed.
    /// </summary>
    public sealed class ToolsRemovedEvent : IEvent
    {
        /// <summary>
        /// Array of tools that were removed.
        /// </summary>
        [JsonPropertyName("tools")]
        public RemovedTool[] Tools
        {
            get;
            set;
        }
    }
}
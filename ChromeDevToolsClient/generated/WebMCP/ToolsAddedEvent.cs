namespace Zu.ChromeDevTools.WebMCP
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Event fired when new tools are added.
    /// </summary>
    public sealed class ToolsAddedEvent : IEvent
    {
        /// <summary>
        /// Array of tools that were added.
        /// </summary>
        [JsonPropertyName("tools")]
        public Tool[] Tools
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.WebMCP
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Definition of a tool that was removed.
    /// </summary>
    public sealed class RemovedTool
    {
        /// <summary>
        /// Tool name.
        ///</summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Frame identifier associated with the tool registration.
        ///</summary>
        [JsonPropertyName("frameId")]
        public string FrameId
        {
            get;
            set;
        }
    }
}
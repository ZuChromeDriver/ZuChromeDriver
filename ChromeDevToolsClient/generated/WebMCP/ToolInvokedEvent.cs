namespace Zu.ChromeDevTools.WebMCP
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Event fired when a tool invocation starts.
    /// </summary>
    public sealed class ToolInvokedEvent : IEvent
    {
        /// <summary>
        /// Name of the tool to invoke.
        /// </summary>
        [JsonPropertyName("toolName")]
        public string ToolName
        {
            get;
            set;
        }
        /// <summary>
        /// Frame id
        /// </summary>
        [JsonPropertyName("frameId")]
        public string FrameId
        {
            get;
            set;
        }
        /// <summary>
        /// Invocation identifier.
        /// </summary>
        [JsonPropertyName("invocationId")]
        public string InvocationId
        {
            get;
            set;
        }
        /// <summary>
        /// The input parameters used for the invocation.
        /// </summary>
        [JsonPropertyName("input")]
        public string Input
        {
            get;
            set;
        }
    }
}
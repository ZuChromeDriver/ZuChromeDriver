namespace Zu.ChromeDevTools.WebMCP
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Definition of a tool that can be invoked.
    /// </summary>
    public sealed class Tool
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
        /// Tool description.
        ///</summary>
        [JsonPropertyName("description")]
        public string Description
        {
            get;
            set;
        }
        /// <summary>
        /// Schema for the tool's input parameters.
        ///</summary>
        [JsonPropertyName("inputSchema")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public object InputSchema
        {
            get;
            set;
        }
        /// <summary>
        /// Optional annotations for the tool.
        ///</summary>
        [JsonPropertyName("annotations")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Annotation Annotations
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
        /// <summary>
        /// Optional node ID for declarative tools.
        ///</summary>
        [JsonPropertyName("backendNodeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? BackendNodeId
        {
            get;
            set;
        }
        /// <summary>
        /// The stack trace at the time of the registration.
        ///</summary>
        [JsonPropertyName("stackTrace")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Runtime.StackTrace StackTrace
        {
            get;
            set;
        }
    }
}
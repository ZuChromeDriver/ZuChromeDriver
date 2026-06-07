namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns node id at given location. Depending on whether DOM domain is enabled, nodeId is
    /// either returned or not.
    /// </summary>
    public sealed class GetNodeForLocationCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOM.getNodeForLocation";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// X coordinate.
        /// </summary>
        [JsonPropertyName("x")]
        public long X
        {
            get;
            set;
        }
        /// <summary>
        /// Y coordinate.
        /// </summary>
        [JsonPropertyName("y")]
        public long Y
        {
            get;
            set;
        }
        /// <summary>
        /// False to skip to the nearest non-UA shadow root ancestor (default: false).
        /// </summary>
        [JsonPropertyName("includeUserAgentShadowDOM")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? IncludeUserAgentShadowDOM
        {
            get;
            set;
        }
        /// <summary>
        /// Whether to ignore pointer-events: none on elements and hit test them.
        /// </summary>
        [JsonPropertyName("ignorePointerEventsNone")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? IgnorePointerEventsNone
        {
            get;
            set;
        }
    }

    public sealed class GetNodeForLocationCommandResponse : ICommandResponse<GetNodeForLocationCommand>
    {
        /// <summary>
        /// Resulting node.
        ///</summary>
        [JsonPropertyName("backendNodeId")]
        public long BackendNodeId
        {
            get;
            set;
        }
        /// <summary>
        /// Frame this node belongs to.
        ///</summary>
        [JsonPropertyName("frameId")]
        public string FrameId
        {
            get;
            set;
        }
        /// <summary>
        /// Id of the node at given coordinates, only when enabled and requested document.
        ///</summary>
        [JsonPropertyName("nodeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? NodeId
        {
            get;
            set;
        }
    }
}
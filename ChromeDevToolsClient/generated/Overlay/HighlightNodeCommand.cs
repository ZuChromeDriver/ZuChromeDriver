namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Highlights DOM node with given id or with the given JavaScript object wrapper. Either nodeId or
    /// objectId must be specified.
    /// </summary>
    public sealed class HighlightNodeCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Overlay.highlightNode";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// A descriptor for the highlight appearance.
        /// </summary>
        [JsonPropertyName("highlightConfig")]
        public HighlightConfig HighlightConfig
        {
            get;
            set;
        }
        /// <summary>
        /// Identifier of the node to highlight.
        /// </summary>
        [JsonPropertyName("nodeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? NodeId
        {
            get;
            set;
        }
        /// <summary>
        /// Identifier of the backend node to highlight.
        /// </summary>
        [JsonPropertyName("backendNodeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? BackendNodeId
        {
            get;
            set;
        }
        /// <summary>
        /// JavaScript object id of the node to be highlighted.
        /// </summary>
        [JsonPropertyName("objectId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ObjectId
        {
            get;
            set;
        }
        /// <summary>
        /// Selectors to highlight relevant nodes.
        /// </summary>
        [JsonPropertyName("selector")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Selector
        {
            get;
            set;
        }
    }

    public sealed class HighlightNodeCommandResponse : ICommandResponse<HighlightNodeCommand>
    {
    }
}
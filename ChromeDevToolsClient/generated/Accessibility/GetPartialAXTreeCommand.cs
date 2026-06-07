namespace Zu.ChromeDevTools.Accessibility
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fetches the accessibility node and partial accessibility tree for this DOM node, if it exists.
    /// </summary>
    public sealed class GetPartialAXTreeCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Accessibility.getPartialAXTree";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Identifier of the node to get the partial accessibility tree for.
        /// </summary>
        [JsonPropertyName("nodeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? NodeId
        {
            get;
            set;
        }
        /// <summary>
        /// Identifier of the backend node to get the partial accessibility tree for.
        /// </summary>
        [JsonPropertyName("backendNodeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? BackendNodeId
        {
            get;
            set;
        }
        /// <summary>
        /// JavaScript object id of the node wrapper to get the partial accessibility tree for.
        /// </summary>
        [JsonPropertyName("objectId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ObjectId
        {
            get;
            set;
        }
        /// <summary>
        /// Whether to fetch this node's ancestors, siblings and children. Defaults to true.
        /// </summary>
        [JsonPropertyName("fetchRelatives")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? FetchRelatives
        {
            get;
            set;
        }
    }

    public sealed class GetPartialAXTreeCommandResponse : ICommandResponse<GetPartialAXTreeCommand>
    {
        /// <summary>
        /// The `Accessibility.AXNode` for this DOM node, if it exists, plus its ancestors, siblings and
        /// children, if requested.
        ///</summary>
        [JsonPropertyName("nodes")]
        public AXNode[] Nodes
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.Accessibility
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fetches a node and all ancestors up to and including the root.
    /// Requires `enable()` to have been called previously.
    /// </summary>
    public sealed class GetAXNodeAndAncestorsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Accessibility.getAXNodeAndAncestors";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Identifier of the node to get.
        /// </summary>
        [JsonPropertyName("nodeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? NodeId
        {
            get;
            set;
        }
        /// <summary>
        /// Identifier of the backend node to get.
        /// </summary>
        [JsonPropertyName("backendNodeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? BackendNodeId
        {
            get;
            set;
        }
        /// <summary>
        /// JavaScript object id of the node wrapper to get.
        /// </summary>
        [JsonPropertyName("objectId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ObjectId
        {
            get;
            set;
        }
    }

    public sealed class GetAXNodeAndAncestorsCommandResponse : ICommandResponse<GetAXNodeAndAncestorsCommand>
    {
        /// <summary>
        /// Gets or sets the nodes
        /// </summary>
        [JsonPropertyName("nodes")]
        public AXNode[] Nodes
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns boxes for the given node.
    /// </summary>
    public sealed class GetBoxModelCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOM.getBoxModel";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Identifier of the node.
        /// </summary>
        [JsonPropertyName("nodeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? NodeId
        {
            get;
            set;
        }
        /// <summary>
        /// Identifier of the backend node.
        /// </summary>
        [JsonPropertyName("backendNodeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? BackendNodeId
        {
            get;
            set;
        }
        /// <summary>
        /// JavaScript object id of the node wrapper.
        /// </summary>
        [JsonPropertyName("objectId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ObjectId
        {
            get;
            set;
        }
    }

    public sealed class GetBoxModelCommandResponse : ICommandResponse<GetBoxModelCommand>
    {
        /// <summary>
        /// Box model for the node.
        ///</summary>
        [JsonPropertyName("model")]
        public BoxModel Model
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns quads that describe node position on the page. This method
    /// might return multiple quads for inline nodes.
    /// </summary>
    public sealed class GetContentQuadsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOM.getContentQuads";
        
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

    public sealed class GetContentQuadsCommandResponse : ICommandResponse<GetContentQuadsCommand>
    {
        /// <summary>
        /// Quads that describe node layout relative to viewport.
        ///</summary>
        [JsonPropertyName("quads")]
        public double[][] Quads
        {
            get;
            set;
        }
    }
}
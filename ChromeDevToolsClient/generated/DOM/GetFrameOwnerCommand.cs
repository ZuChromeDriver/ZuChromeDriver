namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns iframe node that owns iframe with the given domain.
    /// </summary>
    public sealed class GetFrameOwnerCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOM.getFrameOwner";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the frameId
        /// </summary>
        [JsonPropertyName("frameId")]
        public string FrameId
        {
            get;
            set;
        }
    }

    public sealed class GetFrameOwnerCommandResponse : ICommandResponse<GetFrameOwnerCommand>
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
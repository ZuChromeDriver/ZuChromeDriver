namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Sets node name for a node with given id.
    /// </summary>
    public sealed class SetNodeNameCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOM.setNodeName";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Id of the node to set name for.
        /// </summary>
        [JsonPropertyName("nodeId")]
        public long NodeId
        {
            get;
            set;
        }
        /// <summary>
        /// New node's name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
    }

    public sealed class SetNodeNameCommandResponse : ICommandResponse<SetNodeNameCommand>
    {
        /// <summary>
        /// New node's id.
        ///</summary>
        [JsonPropertyName("nodeId")]
        public long NodeId
        {
            get;
            set;
        }
    }
}
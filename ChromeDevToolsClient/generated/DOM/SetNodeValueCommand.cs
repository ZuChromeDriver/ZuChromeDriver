namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Sets node value for a node with given id.
    /// </summary>
    public sealed class SetNodeValueCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOM.setNodeValue";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Id of the node to set value for.
        /// </summary>
        [JsonPropertyName("nodeId")]
        public long NodeId
        {
            get;
            set;
        }
        /// <summary>
        /// New node's value.
        /// </summary>
        [JsonPropertyName("value")]
        public string Value
        {
            get;
            set;
        }
    }

    public sealed class SetNodeValueCommandResponse : ICommandResponse<SetNodeValueCommand>
    {
    }
}
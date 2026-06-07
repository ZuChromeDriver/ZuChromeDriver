namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Removes node with given id.
    /// </summary>
    public sealed class RemoveNodeCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOM.removeNode";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Id of the node to remove.
        /// </summary>
        [JsonPropertyName("nodeId")]
        public long NodeId
        {
            get;
            set;
        }
    }

    public sealed class RemoveNodeCommandResponse : ICommandResponse<RemoveNodeCommand>
    {
    }
}
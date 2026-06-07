namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Collects class names for the node with given id and all of it's child nodes.
    /// </summary>
    public sealed class CollectClassNamesFromSubtreeCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOM.collectClassNamesFromSubtree";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Id of the node to collect class names.
        /// </summary>
        [JsonPropertyName("nodeId")]
        public long NodeId
        {
            get;
            set;
        }
    }

    public sealed class CollectClassNamesFromSubtreeCommandResponse : ICommandResponse<CollectClassNamesFromSubtreeCommand>
    {
        /// <summary>
        /// Class name list.
        ///</summary>
        [JsonPropertyName("classNames")]
        public string[] ClassNames
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Creates a deep copy of the specified node and places it into the target container before the
    /// given anchor.
    /// </summary>
    public sealed class CopyToCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOM.copyTo";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Id of the node to copy.
        /// </summary>
        [JsonPropertyName("nodeId")]
        public long NodeId
        {
            get;
            set;
        }
        /// <summary>
        /// Id of the element to drop the copy into.
        /// </summary>
        [JsonPropertyName("targetNodeId")]
        public long TargetNodeId
        {
            get;
            set;
        }
        /// <summary>
        /// Drop the copy before this node (if absent, the copy becomes the last child of
        /// `targetNodeId`).
        /// </summary>
        [JsonPropertyName("insertBeforeNodeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? InsertBeforeNodeId
        {
            get;
            set;
        }
    }

    public sealed class CopyToCommandResponse : ICommandResponse<CopyToCommand>
    {
        /// <summary>
        /// Id of the node clone.
        ///</summary>
        [JsonPropertyName("nodeId")]
        public long NodeId
        {
            get;
            set;
        }
    }
}
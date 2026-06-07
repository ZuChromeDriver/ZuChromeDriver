namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Requests that children of the node with given id are returned to the caller in form of
    /// `setChildNodes` events where not only immediate children are retrieved, but all children down to
    /// the specified depth.
    /// </summary>
    public sealed class RequestChildNodesCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOM.requestChildNodes";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Id of the node to get children for.
        /// </summary>
        [JsonPropertyName("nodeId")]
        public long NodeId
        {
            get;
            set;
        }
        /// <summary>
        /// The maximum depth at which children should be retrieved, defaults to 1. Use -1 for the
        /// entire subtree or provide an integer larger than 0.
        /// </summary>
        [JsonPropertyName("depth")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Depth
        {
            get;
            set;
        }
        /// <summary>
        /// Whether or not iframes and shadow roots should be traversed when returning the sub-tree
        /// (default is false).
        /// </summary>
        [JsonPropertyName("pierce")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Pierce
        {
            get;
            set;
        }
    }

    public sealed class RequestChildNodesCommandResponse : ICommandResponse<RequestChildNodesCommand>
    {
    }
}
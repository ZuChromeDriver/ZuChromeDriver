namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Executes `querySelector` on a given node.
    /// </summary>
    public sealed class QuerySelectorCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOM.querySelector";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Id of the node to query upon.
        /// </summary>
        [JsonPropertyName("nodeId")]
        public long NodeId
        {
            get;
            set;
        }
        /// <summary>
        /// Selector string.
        /// </summary>
        [JsonPropertyName("selector")]
        public string Selector
        {
            get;
            set;
        }
    }

    public sealed class QuerySelectorCommandResponse : ICommandResponse<QuerySelectorCommand>
    {
        /// <summary>
        /// Query selector result.
        ///</summary>
        [JsonPropertyName("nodeId")]
        public long NodeId
        {
            get;
            set;
        }
    }
}
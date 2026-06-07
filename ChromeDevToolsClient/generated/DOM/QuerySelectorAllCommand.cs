namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Executes `querySelectorAll` on a given node.
    /// </summary>
    public sealed class QuerySelectorAllCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOM.querySelectorAll";
        
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

    public sealed class QuerySelectorAllCommandResponse : ICommandResponse<QuerySelectorAllCommand>
    {
        /// <summary>
        /// Query selector result.
        ///</summary>
        [JsonPropertyName("nodeIds")]
        public long[] NodeIds
        {
            get;
            set;
        }
    }
}
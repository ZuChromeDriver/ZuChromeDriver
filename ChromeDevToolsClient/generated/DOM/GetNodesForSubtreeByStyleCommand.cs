namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Finds nodes with a given computed style in a subtree.
    /// </summary>
    public sealed class GetNodesForSubtreeByStyleCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOM.getNodesForSubtreeByStyle";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Node ID pointing to the root of a subtree.
        /// </summary>
        [JsonPropertyName("nodeId")]
        public long NodeId
        {
            get;
            set;
        }
        /// <summary>
        /// The style to filter nodes by (includes nodes if any of properties matches).
        /// </summary>
        [JsonPropertyName("computedStyles")]
        public CSSComputedStyleProperty[] ComputedStyles
        {
            get;
            set;
        }
        /// <summary>
        /// Whether or not iframes and shadow roots in the same target should be traversed when returning the
        /// results (default is false).
        /// </summary>
        [JsonPropertyName("pierce")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Pierce
        {
            get;
            set;
        }
    }

    public sealed class GetNodesForSubtreeByStyleCommandResponse : ICommandResponse<GetNodesForSubtreeByStyleCommand>
    {
        /// <summary>
        /// Resulting nodes.
        ///</summary>
        [JsonPropertyName("nodeIds")]
        public long[] NodeIds
        {
            get;
            set;
        }
    }
}
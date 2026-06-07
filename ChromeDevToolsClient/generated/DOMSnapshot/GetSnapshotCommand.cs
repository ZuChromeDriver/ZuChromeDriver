namespace Zu.ChromeDevTools.DOMSnapshot
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns a document snapshot, including the full DOM tree of the root node (including iframes,
    /// template contents, and imported documents) in a flattened array, as well as layout and
    /// white-listed computed style information for the nodes. Shadow DOM in the returned DOM tree is
    /// flattened.
    /// </summary>
    public sealed class GetSnapshotCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOMSnapshot.getSnapshot";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Whitelist of computed styles to return.
        /// </summary>
        [JsonPropertyName("computedStyleWhitelist")]
        public string[] ComputedStyleWhitelist
        {
            get;
            set;
        }
        /// <summary>
        /// Whether or not to retrieve details of DOM listeners (default false).
        /// </summary>
        [JsonPropertyName("includeEventListeners")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? IncludeEventListeners
        {
            get;
            set;
        }
        /// <summary>
        /// Whether to determine and include the paint order index of LayoutTreeNodes (default false).
        /// </summary>
        [JsonPropertyName("includePaintOrder")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? IncludePaintOrder
        {
            get;
            set;
        }
        /// <summary>
        /// Whether to include UA shadow tree in the snapshot (default false).
        /// </summary>
        [JsonPropertyName("includeUserAgentShadowTree")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? IncludeUserAgentShadowTree
        {
            get;
            set;
        }
    }

    public sealed class GetSnapshotCommandResponse : ICommandResponse<GetSnapshotCommand>
    {
        /// <summary>
        /// The nodes in the DOM tree. The DOMNode at index 0 corresponds to the root document.
        ///</summary>
        [JsonPropertyName("domNodes")]
        public DOMNode[] DomNodes
        {
            get;
            set;
        }
        /// <summary>
        /// The nodes in the layout tree.
        ///</summary>
        [JsonPropertyName("layoutTreeNodes")]
        public LayoutTreeNode[] LayoutTreeNodes
        {
            get;
            set;
        }
        /// <summary>
        /// Whitelisted ComputedStyle properties for each node in the layout tree.
        ///</summary>
        [JsonPropertyName("computedStyles")]
        public ComputedStyle[] ComputedStyles
        {
            get;
            set;
        }
    }
}
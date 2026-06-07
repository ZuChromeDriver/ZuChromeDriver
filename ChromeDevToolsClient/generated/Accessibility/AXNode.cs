namespace Zu.ChromeDevTools.Accessibility
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// A node in the accessibility tree.
    /// </summary>
    public sealed class AXNode
    {
        /// <summary>
        /// Unique identifier for this node.
        ///</summary>
        [JsonPropertyName("nodeId")]
        public string NodeId
        {
            get;
            set;
        }
        /// <summary>
        /// Whether this node is ignored for accessibility
        ///</summary>
        [JsonPropertyName("ignored")]
        public bool Ignored
        {
            get;
            set;
        }
        /// <summary>
        /// Collection of reasons why this node is hidden.
        ///</summary>
        [JsonPropertyName("ignoredReasons")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public AXProperty[] IgnoredReasons
        {
            get;
            set;
        }
        /// <summary>
        /// This `Node`'s role, whether explicit or implicit.
        ///</summary>
        [JsonPropertyName("role")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public AXValue Role
        {
            get;
            set;
        }
        /// <summary>
        /// This `Node`'s Chrome raw role.
        ///</summary>
        [JsonPropertyName("chromeRole")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public AXValue ChromeRole
        {
            get;
            set;
        }
        /// <summary>
        /// The accessible name for this `Node`.
        ///</summary>
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public AXValue Name
        {
            get;
            set;
        }
        /// <summary>
        /// The accessible description for this `Node`.
        ///</summary>
        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public AXValue Description
        {
            get;
            set;
        }
        /// <summary>
        /// The value for this `Node`.
        ///</summary>
        [JsonPropertyName("value")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public AXValue Value
        {
            get;
            set;
        }
        /// <summary>
        /// All other properties
        ///</summary>
        [JsonPropertyName("properties")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public AXProperty[] Properties
        {
            get;
            set;
        }
        /// <summary>
        /// ID for this node's parent.
        ///</summary>
        [JsonPropertyName("parentId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ParentId
        {
            get;
            set;
        }
        /// <summary>
        /// IDs for each of this node's child nodes.
        ///</summary>
        [JsonPropertyName("childIds")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string[] ChildIds
        {
            get;
            set;
        }
        /// <summary>
        /// The backend ID for the associated DOM node, if any.
        ///</summary>
        [JsonPropertyName("backendDOMNodeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? BackendDOMNodeId
        {
            get;
            set;
        }
        /// <summary>
        /// The frame ID for the frame associated with this nodes document.
        ///</summary>
        [JsonPropertyName("frameId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string FrameId
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Backend node with a friendly name.
    /// </summary>
    public sealed class BackendNode
    {
        /// <summary>
        /// `Node`'s nodeType.
        ///</summary>
        [JsonPropertyName("nodeType")]
        public long NodeType
        {
            get;
            set;
        }
        /// <summary>
        /// `Node`'s nodeName.
        ///</summary>
        [JsonPropertyName("nodeName")]
        public string NodeName
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the backendNodeId
        /// </summary>
        [JsonPropertyName("backendNodeId")]
        public long BackendNodeId
        {
            get;
            set;
        }
    }
}
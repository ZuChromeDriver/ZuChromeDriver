namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Configurations for Persistent Grid Highlight
    /// </summary>
    public sealed class GridNodeHighlightConfig
    {
        /// <summary>
        /// A descriptor for the highlight appearance.
        ///</summary>
        [JsonPropertyName("gridHighlightConfig")]
        public GridHighlightConfig GridHighlightConfig
        {
            get;
            set;
        }
        /// <summary>
        /// Identifier of the node to highlight.
        ///</summary>
        [JsonPropertyName("nodeId")]
        public long NodeId
        {
            get;
            set;
        }
    }
}
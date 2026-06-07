namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class ScrollSnapHighlightConfig
    {
        /// <summary>
        /// A descriptor for the highlight appearance of scroll snap containers.
        ///</summary>
        [JsonPropertyName("scrollSnapContainerHighlightConfig")]
        public ScrollSnapContainerHighlightConfig ScrollSnapContainerHighlightConfig
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
namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class FlexNodeHighlightConfig
    {
        /// <summary>
        /// A descriptor for the highlight appearance of flex containers.
        ///</summary>
        [JsonPropertyName("flexContainerHighlightConfig")]
        public FlexContainerHighlightConfig FlexContainerHighlightConfig
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
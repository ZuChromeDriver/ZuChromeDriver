namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class ContainerQueryHighlightConfig
    {
        /// <summary>
        /// A descriptor for the highlight appearance of container query containers.
        ///</summary>
        [JsonPropertyName("containerQueryContainerHighlightConfig")]
        public ContainerQueryContainerHighlightConfig ContainerQueryContainerHighlightConfig
        {
            get;
            set;
        }
        /// <summary>
        /// Identifier of the container node to highlight.
        ///</summary>
        [JsonPropertyName("nodeId")]
        public long NodeId
        {
            get;
            set;
        }
    }
}
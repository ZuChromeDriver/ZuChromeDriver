namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class IsolatedElementHighlightConfig
    {
        /// <summary>
        /// A descriptor for the highlight appearance of an element in isolation mode.
        ///</summary>
        [JsonPropertyName("isolationModeHighlightConfig")]
        public IsolationModeHighlightConfig IsolationModeHighlightConfig
        {
            get;
            set;
        }
        /// <summary>
        /// Identifier of the isolated element to highlight.
        ///</summary>
        [JsonPropertyName("nodeId")]
        public long NodeId
        {
            get;
            set;
        }
    }
}
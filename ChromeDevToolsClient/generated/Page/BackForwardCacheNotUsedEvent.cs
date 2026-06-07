namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired for failed bfcache history navigations if BackForwardCache feature is enabled. Do
    /// not assume any ordering with the Page.frameNavigated event. This event is fired only for
    /// main-frame history navigation where the document changes (non-same-document navigations),
    /// when bfcache navigation fails.
    /// </summary>
    public sealed class BackForwardCacheNotUsedEvent : IEvent
    {
        /// <summary>
        /// The loader id for the associated navigation.
        /// </summary>
        [JsonPropertyName("loaderId")]
        public string LoaderId
        {
            get;
            set;
        }
        /// <summary>
        /// The frame id of the associated frame.
        /// </summary>
        [JsonPropertyName("frameId")]
        public string FrameId
        {
            get;
            set;
        }
        /// <summary>
        /// Array of reasons why the page could not be cached. This must not be empty.
        /// </summary>
        [JsonPropertyName("notRestoredExplanations")]
        public BackForwardCacheNotRestoredExplanation[] NotRestoredExplanations
        {
            get;
            set;
        }
        /// <summary>
        /// Tree structure of reasons why the page could not be cached for each frame.
        /// </summary>
        [JsonPropertyName("notRestoredExplanationsTree")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public BackForwardCacheNotRestoredExplanationTree NotRestoredExplanationsTree
        {
            get;
            set;
        }
    }
}
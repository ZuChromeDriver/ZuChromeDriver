namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when same-document navigation happens, e.g. due to history API usage or anchor navigation.
    /// </summary>
    public sealed class NavigatedWithinDocumentEvent : IEvent
    {
        /// <summary>
        /// Id of the frame.
        /// </summary>
        [JsonPropertyName("frameId")]
        public string FrameId
        {
            get;
            set;
        }
        /// <summary>
        /// Frame's new url.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// Navigation type
        /// </summary>
        [JsonPropertyName("navigationType")]
        public string NavigationType
        {
            get;
            set;
        }
    }
}
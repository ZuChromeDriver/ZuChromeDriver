namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when a renderer-initiated navigation is requested.
    /// Navigation may still be cancelled after the event is issued.
    /// </summary>
    public sealed class FrameRequestedNavigationEvent : IEvent
    {
        /// <summary>
        /// Id of the frame that is being navigated.
        /// </summary>
        [JsonPropertyName("frameId")]
        public string FrameId
        {
            get;
            set;
        }
        /// <summary>
        /// The reason for the navigation.
        /// </summary>
        [JsonPropertyName("reason")]
        public ClientNavigationReason Reason
        {
            get;
            set;
        }
        /// <summary>
        /// The destination URL for the requested navigation.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// The disposition for the navigation.
        /// </summary>
        [JsonPropertyName("disposition")]
        public ClientNavigationDisposition Disposition
        {
            get;
            set;
        }
    }
}
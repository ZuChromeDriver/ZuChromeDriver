namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when frame schedules a potential navigation.
    /// </summary>
    public sealed class FrameScheduledNavigationEvent : IEvent
    {
        /// <summary>
        /// Id of the frame that has scheduled a navigation.
        /// </summary>
        [JsonPropertyName("frameId")]
        public string FrameId
        {
            get;
            set;
        }
        /// <summary>
        /// Delay (in seconds) until the navigation is scheduled to begin. The navigation is not
        /// guaranteed to start.
        /// </summary>
        [JsonPropertyName("delay")]
        public double Delay
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
        /// The destination URL for the scheduled navigation.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url
        {
            get;
            set;
        }
    }
}
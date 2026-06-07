namespace Zu.ChromeDevTools.PerformanceTimeline
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Sent when a performance timeline event is added. See reportPerformanceTimeline method.
    /// </summary>
    public sealed class TimelineEventAddedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the event
        /// </summary>
        [JsonPropertyName("event")]
        public TimelineEvent Event
        {
            get;
            set;
        }
    }
}
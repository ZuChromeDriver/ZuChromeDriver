namespace Zu.ChromeDevTools.Tracing
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Contains a bucket of collected trace events. When tracing is stopped collected events will be
    /// sent as a sequence of dataCollected events followed by tracingComplete event.
    /// </summary>
    public sealed class DataCollectedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the value
        /// </summary>
        [JsonPropertyName("value")]
        public object[] Value
        {
            get;
            set;
        }
    }
}
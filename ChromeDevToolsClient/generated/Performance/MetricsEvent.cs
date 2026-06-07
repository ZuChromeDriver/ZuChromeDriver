namespace Zu.ChromeDevTools.Performance
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Current values of the metrics.
    /// </summary>
    public sealed class MetricsEvent : IEvent
    {
        /// <summary>
        /// Current values of the metrics.
        /// </summary>
        [JsonPropertyName("metrics")]
        public Metric[] Metrics
        {
            get;
            set;
        }
        /// <summary>
        /// Timestamp title.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title
        {
            get;
            set;
        }
    }
}
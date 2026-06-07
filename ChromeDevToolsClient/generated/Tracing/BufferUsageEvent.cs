namespace Zu.ChromeDevTools.Tracing
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class BufferUsageEvent : IEvent
    {
        /// <summary>
        /// A number in range [0..1] that indicates the used size of event buffer as a fraction of its
        /// total size.
        /// </summary>
        [JsonPropertyName("percentFull")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? PercentFull
        {
            get;
            set;
        }
        /// <summary>
        /// An approximate number of events in the trace log.
        /// </summary>
        [JsonPropertyName("eventCount")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? EventCount
        {
            get;
            set;
        }
        /// <summary>
        /// A number in range [0..1] that indicates the used size of event buffer as a fraction of its
        /// total size.
        /// </summary>
        [JsonPropertyName("value")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? Value
        {
            get;
            set;
        }
    }
}
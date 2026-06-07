namespace Zu.ChromeDevTools.PerformanceTimeline
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class TimelineEvent
    {
        /// <summary>
        /// Identifies the frame that this event is related to. Empty for non-frame targets.
        ///</summary>
        [JsonPropertyName("frameId")]
        public string FrameId
        {
            get;
            set;
        }
        /// <summary>
        /// The event type, as specified in https://w3c.github.io/performance-timeline/#dom-performanceentry-entrytype
        /// This determines which of the optional "details" fields is present.
        ///</summary>
        [JsonPropertyName("type")]
        public string Type
        {
            get;
            set;
        }
        /// <summary>
        /// Name may be empty depending on the type.
        ///</summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Time in seconds since Epoch, monotonically increasing within document lifetime.
        ///</summary>
        [JsonPropertyName("time")]
        public double Time
        {
            get;
            set;
        }
        /// <summary>
        /// Event duration, if applicable.
        ///</summary>
        [JsonPropertyName("duration")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? Duration
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the lcpDetails
        /// </summary>
        [JsonPropertyName("lcpDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public LargestContentfulPaint LcpDetails
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the layoutShiftDetails
        /// </summary>
        [JsonPropertyName("layoutShiftDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public LayoutShift LayoutShiftDetails
        {
            get;
            set;
        }
    }
}
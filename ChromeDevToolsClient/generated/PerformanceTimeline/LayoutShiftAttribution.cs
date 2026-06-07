namespace Zu.ChromeDevTools.PerformanceTimeline
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class LayoutShiftAttribution
    {
        /// <summary>
        /// Gets or sets the previousRect
        /// </summary>
        [JsonPropertyName("previousRect")]
        public DOM.Rect PreviousRect
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the currentRect
        /// </summary>
        [JsonPropertyName("currentRect")]
        public DOM.Rect CurrentRect
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the nodeId
        /// </summary>
        [JsonPropertyName("nodeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? NodeId
        {
            get;
            set;
        }
    }
}
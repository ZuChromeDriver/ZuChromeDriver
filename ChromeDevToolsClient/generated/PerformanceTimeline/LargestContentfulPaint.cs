namespace Zu.ChromeDevTools.PerformanceTimeline
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// See https://github.com/WICG/LargestContentfulPaint and largest_contentful_paint.idl
    /// </summary>
    public sealed class LargestContentfulPaint
    {
        /// <summary>
        /// Gets or sets the renderTime
        /// </summary>
        [JsonPropertyName("renderTime")]
        public double RenderTime
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the loadTime
        /// </summary>
        [JsonPropertyName("loadTime")]
        public double LoadTime
        {
            get;
            set;
        }
        /// <summary>
        /// The number of pixels being painted.
        ///</summary>
        [JsonPropertyName("size")]
        public double Size
        {
            get;
            set;
        }
        /// <summary>
        /// The id attribute of the element, if available.
        ///</summary>
        [JsonPropertyName("elementId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ElementId
        {
            get;
            set;
        }
        /// <summary>
        /// The URL of the image (may be trimmed).
        ///</summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Url
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
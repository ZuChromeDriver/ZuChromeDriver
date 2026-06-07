namespace Zu.ChromeDevTools.Profiler
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Coverage data for a source range.
    /// </summary>
    public sealed class CoverageRange
    {
        /// <summary>
        /// JavaScript script source offset for the range start.
        ///</summary>
        [JsonPropertyName("startOffset")]
        public long StartOffset
        {
            get;
            set;
        }
        /// <summary>
        /// JavaScript script source offset for the range end.
        ///</summary>
        [JsonPropertyName("endOffset")]
        public long EndOffset
        {
            get;
            set;
        }
        /// <summary>
        /// Collected execution count of the source range.
        ///</summary>
        [JsonPropertyName("count")]
        public long Count
        {
            get;
            set;
        }
    }
}
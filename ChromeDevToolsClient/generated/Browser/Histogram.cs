namespace Zu.ChromeDevTools.Browser
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Chrome histogram.
    /// </summary>
    public sealed class Histogram
    {
        /// <summary>
        /// Name.
        ///</summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Sum of sample values.
        ///</summary>
        [JsonPropertyName("sum")]
        public long Sum
        {
            get;
            set;
        }
        /// <summary>
        /// Total number of samples.
        ///</summary>
        [JsonPropertyName("count")]
        public long Count
        {
            get;
            set;
        }
        /// <summary>
        /// Buckets.
        ///</summary>
        [JsonPropertyName("buckets")]
        public Bucket[] Buckets
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.Browser
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Chrome histogram bucket.
    /// </summary>
    public sealed class Bucket
    {
        /// <summary>
        /// Minimum value (inclusive).
        ///</summary>
        [JsonPropertyName("low")]
        public long Low
        {
            get;
            set;
        }
        /// <summary>
        /// Maximum value (exclusive).
        ///</summary>
        [JsonPropertyName("high")]
        public long High
        {
            get;
            set;
        }
        /// <summary>
        /// Number of samples.
        ///</summary>
        [JsonPropertyName("count")]
        public long Count
        {
            get;
            set;
        }
    }
}
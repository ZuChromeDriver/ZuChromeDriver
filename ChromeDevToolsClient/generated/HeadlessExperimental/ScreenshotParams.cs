namespace Zu.ChromeDevTools.HeadlessExperimental
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Encoding options for a screenshot.
    /// </summary>
    public sealed class ScreenshotParams
    {
        /// <summary>
        /// Image compression format (defaults to png).
        ///</summary>
        [JsonPropertyName("format")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Format
        {
            get;
            set;
        }
        /// <summary>
        /// Compression quality from range [0..100] (jpeg and webp only).
        ///</summary>
        [JsonPropertyName("quality")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Quality
        {
            get;
            set;
        }
        /// <summary>
        /// Optimize image encoding for speed, not for resulting size (defaults to false)
        ///</summary>
        [JsonPropertyName("optimizeForSpeed")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? OptimizeForSpeed
        {
            get;
            set;
        }
    }
}
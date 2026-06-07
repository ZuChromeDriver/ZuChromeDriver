namespace Zu.ChromeDevTools.CrashReportContext
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Key-value pair in CrashReportContext.
    /// </summary>
    public sealed class CrashReportContextEntry
    {
        /// <summary>
        /// Gets or sets the key
        /// </summary>
        [JsonPropertyName("key")]
        public string Key
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the value
        /// </summary>
        [JsonPropertyName("value")]
        public string Value
        {
            get;
            set;
        }
        /// <summary>
        /// The ID of the frame where the key-value pair was set.
        ///</summary>
        [JsonPropertyName("frameId")]
        public string FrameId
        {
            get;
            set;
        }
    }
}
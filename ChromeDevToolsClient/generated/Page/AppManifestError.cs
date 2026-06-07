namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Error while paring app manifest.
    /// </summary>
    public sealed class AppManifestError
    {
        /// <summary>
        /// Error message.
        ///</summary>
        [JsonPropertyName("message")]
        public string Message
        {
            get;
            set;
        }
        /// <summary>
        /// If critical, this is a non-recoverable parse error.
        ///</summary>
        [JsonPropertyName("critical")]
        public long Critical
        {
            get;
            set;
        }
        /// <summary>
        /// Error line.
        ///</summary>
        [JsonPropertyName("line")]
        public long Line
        {
            get;
            set;
        }
        /// <summary>
        /// Error column.
        ///</summary>
        [JsonPropertyName("column")]
        public long Column
        {
            get;
            set;
        }
    }
}
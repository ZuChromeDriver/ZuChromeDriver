namespace Zu.ChromeDevTools.Media
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents logged source line numbers reported in an error.
    /// NOTE: file and line are from chromium c++ implementation code, not js.
    /// </summary>
    public sealed class PlayerErrorSourceLocation
    {
        /// <summary>
        /// Gets or sets the file
        /// </summary>
        [JsonPropertyName("file")]
        public string File
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the line
        /// </summary>
        [JsonPropertyName("line")]
        public long Line
        {
            get;
            set;
        }
    }
}
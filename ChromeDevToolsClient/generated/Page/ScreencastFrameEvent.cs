namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Compressed image data requested by the `startScreencast`.
    /// </summary>
    public sealed class ScreencastFrameEvent : IEvent
    {
        /// <summary>
        /// Base64-encoded compressed image. (Encoded as a base64 string when passed over JSON)
        /// </summary>
        [JsonPropertyName("data")]
        public string Data
        {
            get;
            set;
        }
        /// <summary>
        /// Screencast frame metadata.
        /// </summary>
        [JsonPropertyName("metadata")]
        public ScreencastFrameMetadata Metadata
        {
            get;
            set;
        }
        /// <summary>
        /// Frame number.
        /// </summary>
        [JsonPropertyName("sessionId")]
        public long SessionId
        {
            get;
            set;
        }
    }
}
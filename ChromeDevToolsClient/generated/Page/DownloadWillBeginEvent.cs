namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when page is about to start a download.
    /// Deprecated. Use Browser.downloadWillBegin instead.
    /// </summary>
    public sealed class DownloadWillBeginEvent : IEvent
    {
        /// <summary>
        /// Id of the frame that caused download to begin.
        /// </summary>
        [JsonPropertyName("frameId")]
        public string FrameId
        {
            get;
            set;
        }
        /// <summary>
        /// Global unique identifier of the download.
        /// </summary>
        [JsonPropertyName("guid")]
        public string Guid
        {
            get;
            set;
        }
        /// <summary>
        /// URL of the resource being downloaded.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// Suggested file name of the resource (the actual name of the file saved on disk may differ).
        /// </summary>
        [JsonPropertyName("suggestedFilename")]
        public string SuggestedFilename
        {
            get;
            set;
        }
    }
}
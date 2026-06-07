namespace Zu.ChromeDevTools.Browser
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when download makes progress. Last call has |done| == true.
    /// </summary>
    public sealed class DownloadProgressEvent : IEvent
    {
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
        /// Total expected bytes to download.
        /// </summary>
        [JsonPropertyName("totalBytes")]
        public double TotalBytes
        {
            get;
            set;
        }
        /// <summary>
        /// Total bytes received.
        /// </summary>
        [JsonPropertyName("receivedBytes")]
        public double ReceivedBytes
        {
            get;
            set;
        }
        /// <summary>
        /// Download status.
        /// </summary>
        [JsonPropertyName("state")]
        public string State
        {
            get;
            set;
        }
        /// <summary>
        /// If download is "completed", provides the path of the downloaded file.
        /// Depending on the platform, it is not guaranteed to be set, nor the file
        /// is guaranteed to exist.
        /// </summary>
        [JsonPropertyName("filePath")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string FilePath
        {
            get;
            set;
        }
    }
}
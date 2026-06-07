namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Information about the Resource on the page.
    /// </summary>
    public sealed class FrameResource
    {
        /// <summary>
        /// Resource URL.
        ///</summary>
        [JsonPropertyName("url")]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// Type of this resource.
        ///</summary>
        [JsonPropertyName("type")]
        public Network.ResourceType Type
        {
            get;
            set;
        }
        /// <summary>
        /// Resource mimeType as determined by the browser.
        ///</summary>
        [JsonPropertyName("mimeType")]
        public string MimeType
        {
            get;
            set;
        }
        /// <summary>
        /// last-modified timestamp as reported by server.
        ///</summary>
        [JsonPropertyName("lastModified")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? LastModified
        {
            get;
            set;
        }
        /// <summary>
        /// Resource content size.
        ///</summary>
        [JsonPropertyName("contentSize")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? ContentSize
        {
            get;
            set;
        }
        /// <summary>
        /// True if the resource failed to load.
        ///</summary>
        [JsonPropertyName("failed")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Failed
        {
            get;
            set;
        }
        /// <summary>
        /// True if the resource was canceled during loading.
        ///</summary>
        [JsonPropertyName("canceled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Canceled
        {
            get;
            set;
        }
    }
}
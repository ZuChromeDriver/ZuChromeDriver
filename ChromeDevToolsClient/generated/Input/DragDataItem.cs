namespace Zu.ChromeDevTools.Input
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class DragDataItem
    {
        /// <summary>
        /// Mime type of the dragged data.
        ///</summary>
        [JsonPropertyName("mimeType")]
        public string MimeType
        {
            get;
            set;
        }
        /// <summary>
        /// Depending of the value of `mimeType`, it contains the dragged link,
        /// text, HTML markup or any other data.
        ///</summary>
        [JsonPropertyName("data")]
        public string Data
        {
            get;
            set;
        }
        /// <summary>
        /// Title associated with a link. Only valid when `mimeType` == "text/uri-list".
        ///</summary>
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Title
        {
            get;
            set;
        }
        /// <summary>
        /// Stores the base URL for the contained markup. Only valid when `mimeType`
        /// == "text/html".
        ///</summary>
        [JsonPropertyName("baseURL")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string BaseURL
        {
            get;
            set;
        }
    }
}
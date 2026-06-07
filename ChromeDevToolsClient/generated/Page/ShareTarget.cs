namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class ShareTarget
    {
        /// <summary>
        /// Gets or sets the action
        /// </summary>
        [JsonPropertyName("action")]
        public string Action
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the method
        /// </summary>
        [JsonPropertyName("method")]
        public string Method
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the enctype
        /// </summary>
        [JsonPropertyName("enctype")]
        public string Enctype
        {
            get;
            set;
        }
        /// <summary>
        /// Embed the ShareTargetParams
        ///</summary>
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Title
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the text
        /// </summary>
        [JsonPropertyName("text")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Text
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the url
        /// </summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the files
        /// </summary>
        [JsonPropertyName("files")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public FileFilter[] Files
        {
            get;
            set;
        }
    }
}
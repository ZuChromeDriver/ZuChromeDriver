namespace Zu.ChromeDevTools.PWA
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class FileHandler
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
        /// Gets or sets the accepts
        /// </summary>
        [JsonPropertyName("accepts")]
        public FileHandlerAccept[] Accepts
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the displayName
        /// </summary>
        [JsonPropertyName("displayName")]
        public string DisplayName
        {
            get;
            set;
        }
    }
}
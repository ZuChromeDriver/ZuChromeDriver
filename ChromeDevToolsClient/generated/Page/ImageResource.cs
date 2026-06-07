namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// The image definition used in both icon and screenshot.
    /// </summary>
    public sealed class ImageResource
    {
        /// <summary>
        /// The src field in the definition, but changing to url in favor of
        /// consistency.
        ///</summary>
        [JsonPropertyName("url")]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the sizes
        /// </summary>
        [JsonPropertyName("sizes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Sizes
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the type
        /// </summary>
        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Type
        {
            get;
            set;
        }
    }
}
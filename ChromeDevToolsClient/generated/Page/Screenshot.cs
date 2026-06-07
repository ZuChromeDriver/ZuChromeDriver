namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class Screenshot
    {
        /// <summary>
        /// Gets or sets the image
        /// </summary>
        [JsonPropertyName("image")]
        public ImageResource Image
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the formFactor
        /// </summary>
        [JsonPropertyName("formFactor")]
        public string FormFactor
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the label
        /// </summary>
        [JsonPropertyName("label")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Label
        {
            get;
            set;
        }
    }
}
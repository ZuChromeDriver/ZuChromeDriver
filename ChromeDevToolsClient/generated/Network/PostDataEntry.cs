namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Post data entry for HTTP request
    /// </summary>
    public sealed class PostDataEntry
    {
        /// <summary>
        /// Gets or sets the bytes
        /// </summary>
        [JsonPropertyName("bytes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Bytes
        {
            get;
            set;
        }
    }
}
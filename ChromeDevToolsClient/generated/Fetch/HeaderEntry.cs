namespace Zu.ChromeDevTools.Fetch
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Response HTTP header entry
    /// </summary>
    public sealed class HeaderEntry
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the value
        /// </summary>
        [JsonPropertyName("value")]
        public string Value
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.BackgroundService
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// A key-value pair for additional event information to pass along.
    /// </summary>
    public sealed class EventMetadata
    {
        /// <summary>
        /// Gets or sets the key
        /// </summary>
        [JsonPropertyName("key")]
        public string Key
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
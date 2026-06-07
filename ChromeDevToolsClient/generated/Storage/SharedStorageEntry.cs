namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Struct for a single key-value pair in an origin's shared storage.
    /// </summary>
    public sealed class SharedStorageEntry
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
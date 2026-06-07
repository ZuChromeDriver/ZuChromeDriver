namespace Zu.ChromeDevTools.IndexedDB
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Key path.
    /// </summary>
    public sealed class KeyPath
    {
        /// <summary>
        /// Key path type.
        ///</summary>
        [JsonPropertyName("type")]
        public string Type
        {
            get;
            set;
        }
        /// <summary>
        /// String value.
        ///</summary>
        [JsonPropertyName("string")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string String
        {
            get;
            set;
        }
        /// <summary>
        /// Array value.
        ///</summary>
        [JsonPropertyName("array")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string[] Array
        {
            get;
            set;
        }
    }
}
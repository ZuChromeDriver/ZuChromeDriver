namespace Zu.ChromeDevTools.IndexedDB
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Key.
    /// </summary>
    public sealed class Key
    {
        /// <summary>
        /// Key type.
        ///</summary>
        [JsonPropertyName("type")]
        public string Type
        {
            get;
            set;
        }
        /// <summary>
        /// Number value.
        ///</summary>
        [JsonPropertyName("number")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? Number
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
        /// Date value.
        ///</summary>
        [JsonPropertyName("date")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? Date
        {
            get;
            set;
        }
        /// <summary>
        /// Array value.
        ///</summary>
        [JsonPropertyName("array")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Key[] Array
        {
            get;
            set;
        }
    }
}
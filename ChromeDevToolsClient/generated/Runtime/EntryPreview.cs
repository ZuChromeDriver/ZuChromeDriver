namespace Zu.ChromeDevTools.Runtime
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class EntryPreview
    {
        /// <summary>
        /// Preview of the key. Specified for map-like collection entries.
        ///</summary>
        [JsonPropertyName("key")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ObjectPreview Key
        {
            get;
            set;
        }
        /// <summary>
        /// Preview of the value.
        ///</summary>
        [JsonPropertyName("value")]
        public ObjectPreview Value
        {
            get;
            set;
        }
    }
}
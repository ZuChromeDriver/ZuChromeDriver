namespace Zu.ChromeDevTools.IndexedDB
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Data entry.
    /// </summary>
    public sealed class DataEntry
    {
        /// <summary>
        /// Key object.
        ///</summary>
        [JsonPropertyName("key")]
        public Runtime.RemoteObject Key
        {
            get;
            set;
        }
        /// <summary>
        /// Primary key object.
        ///</summary>
        [JsonPropertyName("primaryKey")]
        public Runtime.RemoteObject PrimaryKey
        {
            get;
            set;
        }
        /// <summary>
        /// Value object.
        ///</summary>
        [JsonPropertyName("value")]
        public Runtime.RemoteObject Value
        {
            get;
            set;
        }
    }
}
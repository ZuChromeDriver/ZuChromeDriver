namespace Zu.ChromeDevTools.IndexedDB
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Object store index.
    /// </summary>
    public sealed class ObjectStoreIndex
    {
        /// <summary>
        /// Index name.
        ///</summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Index key path.
        ///</summary>
        [JsonPropertyName("keyPath")]
        public KeyPath KeyPath
        {
            get;
            set;
        }
        /// <summary>
        /// If true, index is unique.
        ///</summary>
        [JsonPropertyName("unique")]
        public bool Unique
        {
            get;
            set;
        }
        /// <summary>
        /// If true, index allows multiple entries for a key.
        ///</summary>
        [JsonPropertyName("multiEntry")]
        public bool MultiEntry
        {
            get;
            set;
        }
    }
}
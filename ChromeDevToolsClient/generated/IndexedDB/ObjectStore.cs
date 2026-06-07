namespace Zu.ChromeDevTools.IndexedDB
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Object store.
    /// </summary>
    public sealed class ObjectStore
    {
        /// <summary>
        /// Object store name.
        ///</summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Object store key path.
        ///</summary>
        [JsonPropertyName("keyPath")]
        public KeyPath KeyPath
        {
            get;
            set;
        }
        /// <summary>
        /// If true, object store has auto increment flag set.
        ///</summary>
        [JsonPropertyName("autoIncrement")]
        public bool AutoIncrement
        {
            get;
            set;
        }
        /// <summary>
        /// Indexes in this object store.
        ///</summary>
        [JsonPropertyName("indexes")]
        public ObjectStoreIndex[] Indexes
        {
            get;
            set;
        }
    }
}
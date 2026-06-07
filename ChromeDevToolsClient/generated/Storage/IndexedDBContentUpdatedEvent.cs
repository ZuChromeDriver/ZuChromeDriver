namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// The origin's IndexedDB object store has been modified.
    /// </summary>
    public sealed class IndexedDBContentUpdatedEvent : IEvent
    {
        /// <summary>
        /// Origin to update.
        /// </summary>
        [JsonPropertyName("origin")]
        public string Origin
        {
            get;
            set;
        }
        /// <summary>
        /// Storage key to update.
        /// </summary>
        [JsonPropertyName("storageKey")]
        public string StorageKey
        {
            get;
            set;
        }
        /// <summary>
        /// Storage bucket to update.
        /// </summary>
        [JsonPropertyName("bucketId")]
        public string BucketId
        {
            get;
            set;
        }
        /// <summary>
        /// Database to update.
        /// </summary>
        [JsonPropertyName("databaseName")]
        public string DatabaseName
        {
            get;
            set;
        }
        /// <summary>
        /// ObjectStore to update.
        /// </summary>
        [JsonPropertyName("objectStoreName")]
        public string ObjectStoreName
        {
            get;
            set;
        }
    }
}
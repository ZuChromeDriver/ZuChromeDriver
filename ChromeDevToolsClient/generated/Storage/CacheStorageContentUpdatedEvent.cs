namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// A cache's contents have been modified.
    /// </summary>
    public sealed class CacheStorageContentUpdatedEvent : IEvent
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
        /// Name of cache in origin.
        /// </summary>
        [JsonPropertyName("cacheName")]
        public string CacheName
        {
            get;
            set;
        }
    }
}
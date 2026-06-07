namespace Zu.ChromeDevTools.CacheStorage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Cache identifier.
    /// </summary>
    public sealed class Cache
    {
        /// <summary>
        /// An opaque unique id of the cache.
        ///</summary>
        [JsonPropertyName("cacheId")]
        public string CacheId
        {
            get;
            set;
        }
        /// <summary>
        /// Security origin of the cache.
        ///</summary>
        [JsonPropertyName("securityOrigin")]
        public string SecurityOrigin
        {
            get;
            set;
        }
        /// <summary>
        /// Storage key of the cache.
        ///</summary>
        [JsonPropertyName("storageKey")]
        public string StorageKey
        {
            get;
            set;
        }
        /// <summary>
        /// Storage bucket of the cache.
        ///</summary>
        [JsonPropertyName("storageBucket")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Storage.StorageBucket StorageBucket
        {
            get;
            set;
        }
        /// <summary>
        /// The name of the cache.
        ///</summary>
        [JsonPropertyName("cacheName")]
        public string CacheName
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.DOMStorage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// DOM Storage identifier.
    /// </summary>
    public sealed class StorageId
    {
        /// <summary>
        /// Security origin for the storage.
        ///</summary>
        [JsonPropertyName("securityOrigin")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string SecurityOrigin
        {
            get;
            set;
        }
        /// <summary>
        /// Represents a key by which DOM Storage keys its CachedStorageAreas
        ///</summary>
        [JsonPropertyName("storageKey")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string StorageKey
        {
            get;
            set;
        }
        /// <summary>
        /// Whether the storage is local storage (not session storage).
        ///</summary>
        [JsonPropertyName("isLocalStorage")]
        public bool IsLocalStorage
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Unregisters storage key from receiving notifications for cache storage.
    /// </summary>
    public sealed class UntrackCacheStorageForStorageKeyCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Storage.untrackCacheStorageForStorageKey";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Storage key.
        /// </summary>
        [JsonPropertyName("storageKey")]
        public string StorageKey
        {
            get;
            set;
        }
    }

    public sealed class UntrackCacheStorageForStorageKeyCommandResponse : ICommandResponse<UntrackCacheStorageForStorageKeyCommand>
    {
    }
}
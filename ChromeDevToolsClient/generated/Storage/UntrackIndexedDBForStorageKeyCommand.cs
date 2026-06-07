namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Unregisters storage key from receiving notifications for IndexedDB.
    /// </summary>
    public sealed class UntrackIndexedDBForStorageKeyCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Storage.untrackIndexedDBForStorageKey";
        
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

    public sealed class UntrackIndexedDBForStorageKeyCommandResponse : ICommandResponse<UntrackIndexedDBForStorageKeyCommand>
    {
    }
}
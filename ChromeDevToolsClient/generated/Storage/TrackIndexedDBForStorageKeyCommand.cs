namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Registers storage key to be notified when an update occurs to its IndexedDB.
    /// </summary>
    public sealed class TrackIndexedDBForStorageKeyCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Storage.trackIndexedDBForStorageKey";
        
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

    public sealed class TrackIndexedDBForStorageKeyCommandResponse : ICommandResponse<TrackIndexedDBForStorageKeyCommand>
    {
    }
}
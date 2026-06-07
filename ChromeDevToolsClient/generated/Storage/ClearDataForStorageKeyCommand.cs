namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Clears storage for storage key.
    /// </summary>
    public sealed class ClearDataForStorageKeyCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Storage.clearDataForStorageKey";
        
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
        /// <summary>
        /// Comma separated list of StorageType to clear.
        /// </summary>
        [JsonPropertyName("storageTypes")]
        public string StorageTypes
        {
            get;
            set;
        }
    }

    public sealed class ClearDataForStorageKeyCommandResponse : ICommandResponse<ClearDataForStorageKeyCommand>
    {
    }
}
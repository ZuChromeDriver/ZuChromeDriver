namespace Zu.ChromeDevTools.DOMStorage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class RemoveDOMStorageItemCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOMStorage.removeDOMStorageItem";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the storageId
        /// </summary>
        [JsonPropertyName("storageId")]
        public StorageId StorageId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the key
        /// </summary>
        [JsonPropertyName("key")]
        public string Key
        {
            get;
            set;
        }
    }

    public sealed class RemoveDOMStorageItemCommandResponse : ICommandResponse<RemoveDOMStorageItemCommand>
    {
    }
}
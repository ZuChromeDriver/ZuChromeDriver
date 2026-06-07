namespace Zu.ChromeDevTools.DOMStorage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class SetDOMStorageItemCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOMStorage.setDOMStorageItem";
        
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
        /// <summary>
        /// Gets or sets the value
        /// </summary>
        [JsonPropertyName("value")]
        public string Value
        {
            get;
            set;
        }
    }

    public sealed class SetDOMStorageItemCommandResponse : ICommandResponse<SetDOMStorageItemCommand>
    {
    }
}
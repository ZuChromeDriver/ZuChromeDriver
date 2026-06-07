namespace Zu.ChromeDevTools.DOMStorage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class GetDOMStorageItemsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOMStorage.getDOMStorageItems";
        
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
    }

    public sealed class GetDOMStorageItemsCommandResponse : ICommandResponse<GetDOMStorageItemsCommand>
    {
        /// <summary>
        /// Gets or sets the entries
        /// </summary>
        [JsonPropertyName("entries")]
        public string[][] Entries
        {
            get;
            set;
        }
    }
}
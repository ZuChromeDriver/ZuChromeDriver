namespace Zu.ChromeDevTools.Extensions
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Clears extension storage in the given `storageArea`.
    /// </summary>
    public sealed class ClearStorageItemsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Extensions.clearStorageItems";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// ID of extension.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id
        {
            get;
            set;
        }
        /// <summary>
        /// StorageArea to remove data from.
        /// </summary>
        [JsonPropertyName("storageArea")]
        public StorageArea StorageArea
        {
            get;
            set;
        }
    }

    public sealed class ClearStorageItemsCommandResponse : ICommandResponse<ClearStorageItemsCommand>
    {
    }
}
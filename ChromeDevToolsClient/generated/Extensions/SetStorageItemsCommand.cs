namespace Zu.ChromeDevTools.Extensions
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Sets `values` in extension storage in the given `storageArea`. The provided `values`
    /// will be merged with existing values in the storage area.
    /// </summary>
    public sealed class SetStorageItemsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Extensions.setStorageItems";
        
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
        /// StorageArea to set data in.
        /// </summary>
        [JsonPropertyName("storageArea")]
        public StorageArea StorageArea
        {
            get;
            set;
        }
        /// <summary>
        /// Values to set.
        /// </summary>
        [JsonPropertyName("values")]
        public object Values
        {
            get;
            set;
        }
    }

    public sealed class SetStorageItemsCommandResponse : ICommandResponse<SetStorageItemsCommand>
    {
    }
}
namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Clears all entries for a given origin's shared storage.
    /// </summary>
    public sealed class ClearSharedStorageEntriesCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Storage.clearSharedStorageEntries";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the ownerOrigin
        /// </summary>
        [JsonPropertyName("ownerOrigin")]
        public string OwnerOrigin
        {
            get;
            set;
        }
    }

    public sealed class ClearSharedStorageEntriesCommandResponse : ICommandResponse<ClearSharedStorageEntriesCommand>
    {
    }
}
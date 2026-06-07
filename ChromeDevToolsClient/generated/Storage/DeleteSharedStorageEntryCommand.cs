namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Deletes entry for `key` (if it exists) for a given origin's shared storage.
    /// </summary>
    public sealed class DeleteSharedStorageEntryCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Storage.deleteSharedStorageEntry";
        
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

    public sealed class DeleteSharedStorageEntryCommandResponse : ICommandResponse<DeleteSharedStorageEntryCommand>
    {
    }
}
namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Gets the entries in an given origin's shared storage.
    /// </summary>
    public sealed class GetSharedStorageEntriesCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Storage.getSharedStorageEntries";
        
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

    public sealed class GetSharedStorageEntriesCommandResponse : ICommandResponse<GetSharedStorageEntriesCommand>
    {
        /// <summary>
        /// Gets or sets the entries
        /// </summary>
        [JsonPropertyName("entries")]
        public SharedStorageEntry[] Entries
        {
            get;
            set;
        }
    }
}
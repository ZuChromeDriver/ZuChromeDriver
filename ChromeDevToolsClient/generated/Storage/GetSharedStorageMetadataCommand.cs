namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Gets metadata for an origin's shared storage.
    /// </summary>
    public sealed class GetSharedStorageMetadataCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Storage.getSharedStorageMetadata";
        
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

    public sealed class GetSharedStorageMetadataCommandResponse : ICommandResponse<GetSharedStorageMetadataCommand>
    {
        /// <summary>
        /// Gets or sets the metadata
        /// </summary>
        [JsonPropertyName("metadata")]
        public SharedStorageMetadata Metadata
        {
            get;
            set;
        }
    }
}
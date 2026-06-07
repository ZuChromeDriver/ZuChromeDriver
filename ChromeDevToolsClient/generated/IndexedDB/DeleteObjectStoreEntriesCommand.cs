namespace Zu.ChromeDevTools.IndexedDB
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Delete a range of entries from an object store
    /// </summary>
    public sealed class DeleteObjectStoreEntriesCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "IndexedDB.deleteObjectStoreEntries";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// At least and at most one of securityOrigin, storageKey, or storageBucket must be specified.
        /// Security origin.
        /// </summary>
        [JsonPropertyName("securityOrigin")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string SecurityOrigin
        {
            get;
            set;
        }
        /// <summary>
        /// Storage key.
        /// </summary>
        [JsonPropertyName("storageKey")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string StorageKey
        {
            get;
            set;
        }
        /// <summary>
        /// Storage bucket. If not specified, it uses the default bucket.
        /// </summary>
        [JsonPropertyName("storageBucket")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Storage.StorageBucket StorageBucket
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the databaseName
        /// </summary>
        [JsonPropertyName("databaseName")]
        public string DatabaseName
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the objectStoreName
        /// </summary>
        [JsonPropertyName("objectStoreName")]
        public string ObjectStoreName
        {
            get;
            set;
        }
        /// <summary>
        /// Range of entry keys to delete
        /// </summary>
        [JsonPropertyName("keyRange")]
        public KeyRange KeyRange
        {
            get;
            set;
        }
    }

    public sealed class DeleteObjectStoreEntriesCommandResponse : ICommandResponse<DeleteObjectStoreEntriesCommand>
    {
    }
}
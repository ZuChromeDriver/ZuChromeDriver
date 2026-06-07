namespace Zu.ChromeDevTools.IndexedDB
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Deletes a database.
    /// </summary>
    public sealed class DeleteDatabaseCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "IndexedDB.deleteDatabase";
        
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
        /// Database name.
        /// </summary>
        [JsonPropertyName("databaseName")]
        public string DatabaseName
        {
            get;
            set;
        }
    }

    public sealed class DeleteDatabaseCommandResponse : ICommandResponse<DeleteDatabaseCommand>
    {
    }
}
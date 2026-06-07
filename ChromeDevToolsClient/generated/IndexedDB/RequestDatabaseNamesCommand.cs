namespace Zu.ChromeDevTools.IndexedDB
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Requests database names for given security origin.
    /// </summary>
    public sealed class RequestDatabaseNamesCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "IndexedDB.requestDatabaseNames";
        
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
    }

    public sealed class RequestDatabaseNamesCommandResponse : ICommandResponse<RequestDatabaseNamesCommand>
    {
        /// <summary>
        /// Database names for origin.
        ///</summary>
        [JsonPropertyName("databaseNames")]
        public string[] DatabaseNames
        {
            get;
            set;
        }
    }
}
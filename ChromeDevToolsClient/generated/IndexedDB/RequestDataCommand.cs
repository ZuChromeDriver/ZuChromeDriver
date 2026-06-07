namespace Zu.ChromeDevTools.IndexedDB
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Requests data from object store or index.
    /// </summary>
    public sealed class RequestDataCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "IndexedDB.requestData";
        
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
        /// <summary>
        /// Object store name.
        /// </summary>
        [JsonPropertyName("objectStoreName")]
        public string ObjectStoreName
        {
            get;
            set;
        }
        /// <summary>
        /// Index name. If not specified, it performs an object store data request.
        /// </summary>
        [JsonPropertyName("indexName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string IndexName
        {
            get;
            set;
        }
        /// <summary>
        /// Number of records to skip.
        /// </summary>
        [JsonPropertyName("skipCount")]
        public long SkipCount
        {
            get;
            set;
        }
        /// <summary>
        /// Number of records to fetch.
        /// </summary>
        [JsonPropertyName("pageSize")]
        public long PageSize
        {
            get;
            set;
        }
        /// <summary>
        /// Key range.
        /// </summary>
        [JsonPropertyName("keyRange")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public KeyRange KeyRange
        {
            get;
            set;
        }
    }

    public sealed class RequestDataCommandResponse : ICommandResponse<RequestDataCommand>
    {
        /// <summary>
        /// Array of object store data entries.
        ///</summary>
        [JsonPropertyName("objectStoreDataEntries")]
        public DataEntry[] ObjectStoreDataEntries
        {
            get;
            set;
        }
        /// <summary>
        /// If true, there are more entries to fetch in the given range.
        ///</summary>
        [JsonPropertyName("hasMore")]
        public bool HasMore
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.CacheStorage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Requests data from cache.
    /// </summary>
    public sealed class RequestEntriesCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "CacheStorage.requestEntries";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// ID of cache to get entries from.
        /// </summary>
        [JsonPropertyName("cacheId")]
        public string CacheId
        {
            get;
            set;
        }
        /// <summary>
        /// Number of records to skip.
        /// </summary>
        [JsonPropertyName("skipCount")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? SkipCount
        {
            get;
            set;
        }
        /// <summary>
        /// Number of records to fetch.
        /// </summary>
        [JsonPropertyName("pageSize")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? PageSize
        {
            get;
            set;
        }
        /// <summary>
        /// If present, only return the entries containing this substring in the path
        /// </summary>
        [JsonPropertyName("pathFilter")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string PathFilter
        {
            get;
            set;
        }
    }

    public sealed class RequestEntriesCommandResponse : ICommandResponse<RequestEntriesCommand>
    {
        /// <summary>
        /// Array of object store data entries.
        ///</summary>
        [JsonPropertyName("cacheDataEntries")]
        public DataEntry[] CacheDataEntries
        {
            get;
            set;
        }
        /// <summary>
        /// Count of returned entries from this storage. If pathFilter is empty, it
        /// is the count of all entries from this storage.
        ///</summary>
        [JsonPropertyName("returnCount")]
        public double ReturnCount
        {
            get;
            set;
        }
    }
}
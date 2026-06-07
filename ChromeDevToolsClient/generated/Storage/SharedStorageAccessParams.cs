namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Bundles the parameters for shared storage access events whose
    /// presence/absence can vary according to SharedStorageAccessType.
    /// </summary>
    public sealed class SharedStorageAccessParams
    {
        /// <summary>
        /// Spec of the module script URL.
        /// Present only for SharedStorageAccessMethods: addModule and
        /// createWorklet.
        ///</summary>
        [JsonPropertyName("scriptSourceUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ScriptSourceUrl
        {
            get;
            set;
        }
        /// <summary>
        /// String denoting "context-origin", "script-origin", or a custom
        /// origin to be used as the worklet's data origin.
        /// Present only for SharedStorageAccessMethod: createWorklet.
        ///</summary>
        [JsonPropertyName("dataOrigin")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string DataOrigin
        {
            get;
            set;
        }
        /// <summary>
        /// Name of the registered operation to be run.
        /// Present only for SharedStorageAccessMethods: run and selectURL.
        ///</summary>
        [JsonPropertyName("operationName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string OperationName
        {
            get;
            set;
        }
        /// <summary>
        /// ID of the operation call.
        /// Present only for SharedStorageAccessMethods: run and selectURL.
        ///</summary>
        [JsonPropertyName("operationId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string OperationId
        {
            get;
            set;
        }
        /// <summary>
        /// Whether or not to keep the worket alive for future run or selectURL
        /// calls.
        /// Present only for SharedStorageAccessMethods: run and selectURL.
        ///</summary>
        [JsonPropertyName("keepAlive")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? KeepAlive
        {
            get;
            set;
        }
        /// <summary>
        /// Configures the private aggregation options.
        /// Present only for SharedStorageAccessMethods: run and selectURL.
        ///</summary>
        [JsonPropertyName("privateAggregationConfig")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public SharedStoragePrivateAggregationConfig PrivateAggregationConfig
        {
            get;
            set;
        }
        /// <summary>
        /// The operation's serialized data in bytes (converted to a string).
        /// Present only for SharedStorageAccessMethods: run and selectURL.
        /// TODO(crbug.com/401011862): Consider updating this parameter to binary.
        ///</summary>
        [JsonPropertyName("serializedData")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string SerializedData
        {
            get;
            set;
        }
        /// <summary>
        /// Array of candidate URLs' specs, along with any associated metadata.
        /// Present only for SharedStorageAccessMethod: selectURL.
        ///</summary>
        [JsonPropertyName("urlsWithMetadata")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public SharedStorageUrlWithMetadata[] UrlsWithMetadata
        {
            get;
            set;
        }
        /// <summary>
        /// Spec of the URN:UUID generated for a selectURL call.
        /// Present only for SharedStorageAccessMethod: selectURL.
        ///</summary>
        [JsonPropertyName("urnUuid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string UrnUuid
        {
            get;
            set;
        }
        /// <summary>
        /// Key for a specific entry in an origin's shared storage.
        /// Present only for SharedStorageAccessMethods: set, append, delete, and
        /// get.
        ///</summary>
        [JsonPropertyName("key")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Key
        {
            get;
            set;
        }
        /// <summary>
        /// Value for a specific entry in an origin's shared storage.
        /// Present only for SharedStorageAccessMethods: set and append.
        ///</summary>
        [JsonPropertyName("value")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Value
        {
            get;
            set;
        }
        /// <summary>
        /// Whether or not to set an entry for a key if that key is already present.
        /// Present only for SharedStorageAccessMethod: set.
        ///</summary>
        [JsonPropertyName("ignoreIfPresent")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? IgnoreIfPresent
        {
            get;
            set;
        }
        /// <summary>
        /// A number denoting the (0-based) order of the worklet's
        /// creation relative to all other shared storage worklets created by
        /// documents using the current storage partition.
        /// Present only for SharedStorageAccessMethods: addModule, createWorklet.
        ///</summary>
        [JsonPropertyName("workletOrdinal")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? WorkletOrdinal
        {
            get;
            set;
        }
        /// <summary>
        /// Hex representation of the DevTools token used as the TargetID for the
        /// associated shared storage worklet.
        /// Present only for SharedStorageAccessMethods: addModule, createWorklet,
        /// run, selectURL, and any other SharedStorageAccessMethod when the
        /// SharedStorageAccessScope is sharedStorageWorklet.
        ///</summary>
        [JsonPropertyName("workletTargetId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string WorkletTargetId
        {
            get;
            set;
        }
        /// <summary>
        /// Name of the lock to be acquired, if present.
        /// Optionally present only for SharedStorageAccessMethods: batchUpdate,
        /// set, append, delete, and clear.
        ///</summary>
        [JsonPropertyName("withLock")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string WithLock
        {
            get;
            set;
        }
        /// <summary>
        /// If the method has been called as part of a batchUpdate, then this
        /// number identifies the batch to which it belongs.
        /// Optionally present only for SharedStorageAccessMethods:
        /// batchUpdate (required), set, append, delete, and clear.
        ///</summary>
        [JsonPropertyName("batchUpdateId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string BatchUpdateId
        {
            get;
            set;
        }
        /// <summary>
        /// Number of modifier methods sent in batch.
        /// Present only for SharedStorageAccessMethod: batchUpdate.
        ///</summary>
        [JsonPropertyName("batchSize")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? BatchSize
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Enum of possible storage types.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StorageType
    {
        [JsonStringEnumMemberName("cookies")]
        Cookies,
        [JsonStringEnumMemberName("file_systems")]
        File_systems,
        [JsonStringEnumMemberName("indexeddb")]
        Indexeddb,
        [JsonStringEnumMemberName("local_storage")]
        Local_storage,
        [JsonStringEnumMemberName("shader_cache")]
        Shader_cache,
        [JsonStringEnumMemberName("websql")]
        Websql,
        [JsonStringEnumMemberName("service_workers")]
        Service_workers,
        [JsonStringEnumMemberName("cache_storage")]
        Cache_storage,
        [JsonStringEnumMemberName("interest_groups")]
        Interest_groups,
        [JsonStringEnumMemberName("shared_storage")]
        Shared_storage,
        [JsonStringEnumMemberName("storage_buckets")]
        Storage_buckets,
        [JsonStringEnumMemberName("all")]
        All,
        [JsonStringEnumMemberName("other")]
        Other,
    }
}
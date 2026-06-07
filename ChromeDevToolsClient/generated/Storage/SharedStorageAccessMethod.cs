namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Enum of shared storage access methods.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SharedStorageAccessMethod
    {
        [JsonStringEnumMemberName("addModule")]
        AddModule,
        [JsonStringEnumMemberName("createWorklet")]
        CreateWorklet,
        [JsonStringEnumMemberName("selectURL")]
        SelectURL,
        [JsonStringEnumMemberName("run")]
        Run,
        [JsonStringEnumMemberName("batchUpdate")]
        BatchUpdate,
        [JsonStringEnumMemberName("set")]
        Set,
        [JsonStringEnumMemberName("append")]
        Append,
        [JsonStringEnumMemberName("delete")]
        Delete,
        [JsonStringEnumMemberName("clear")]
        Clear,
        [JsonStringEnumMemberName("get")]
        Get,
        [JsonStringEnumMemberName("keys")]
        Keys,
        [JsonStringEnumMemberName("values")]
        Values,
        [JsonStringEnumMemberName("entries")]
        Entries,
        [JsonStringEnumMemberName("length")]
        Length,
        [JsonStringEnumMemberName("remainingBudget")]
        RemainingBudget,
    }
}
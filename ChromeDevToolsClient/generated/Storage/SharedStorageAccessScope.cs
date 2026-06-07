namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Enum of shared storage access scopes.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SharedStorageAccessScope
    {
        [JsonStringEnumMemberName("window")]
        Window,
        [JsonStringEnumMemberName("sharedStorageWorklet")]
        SharedStorageWorklet,
        [JsonStringEnumMemberName("protectedAudienceWorklet")]
        ProtectedAudienceWorklet,
        [JsonStringEnumMemberName("header")]
        Header,
    }
}
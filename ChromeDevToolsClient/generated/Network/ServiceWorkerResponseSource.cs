namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Source of serviceworker response.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ServiceWorkerResponseSource
    {
        [JsonStringEnumMemberName("cache-storage")]
        CacheStorage,
        [JsonStringEnumMemberName("http-cache")]
        HttpCache,
        [JsonStringEnumMemberName("fallback-code")]
        FallbackCode,
        [JsonStringEnumMemberName("network")]
        Network,
    }
}
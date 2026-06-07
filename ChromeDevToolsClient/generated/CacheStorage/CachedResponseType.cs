namespace Zu.ChromeDevTools.CacheStorage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// type of HTTP response cached
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CachedResponseType
    {
        [JsonStringEnumMemberName("basic")]
        Basic,
        [JsonStringEnumMemberName("cors")]
        Cors,
        [JsonStringEnumMemberName("default")]
        Default,
        [JsonStringEnumMemberName("error")]
        Error,
        [JsonStringEnumMemberName("opaqueResponse")]
        OpaqueResponse,
        [JsonStringEnumMemberName("opaqueRedirect")]
        OpaqueRedirect,
    }
}
namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// List of content encodings supported by the backend.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ContentEncoding
    {
        [JsonStringEnumMemberName("deflate")]
        Deflate,
        [JsonStringEnumMemberName("gzip")]
        Gzip,
        [JsonStringEnumMemberName("br")]
        Br,
        [JsonStringEnumMemberName("zstd")]
        Zstd,
    }
}
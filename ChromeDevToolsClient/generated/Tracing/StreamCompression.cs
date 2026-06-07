namespace Zu.ChromeDevTools.Tracing
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Compression type to use for traces returned via streams.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StreamCompression
    {
        [JsonStringEnumMemberName("none")]
        None,
        [JsonStringEnumMemberName("gzip")]
        Gzip,
    }
}
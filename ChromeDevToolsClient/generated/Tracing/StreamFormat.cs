namespace Zu.ChromeDevTools.Tracing
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Data format of a trace. Can be either the legacy JSON format or the
    /// protocol buffer format. Note that the JSON format will be deprecated soon.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StreamFormat
    {
        [JsonStringEnumMemberName("json")]
        Json,
        [JsonStringEnumMemberName("proto")]
        Proto,
    }
}
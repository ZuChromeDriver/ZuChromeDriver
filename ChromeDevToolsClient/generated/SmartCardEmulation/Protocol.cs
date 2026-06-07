namespace Zu.ChromeDevTools.SmartCardEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Maps to the |SCARD_PROTOCOL_*| values.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Protocol
    {
        [JsonStringEnumMemberName("t0")]
        T0,
        [JsonStringEnumMemberName("t1")]
        T1,
        [JsonStringEnumMemberName("raw")]
        Raw,
    }
}
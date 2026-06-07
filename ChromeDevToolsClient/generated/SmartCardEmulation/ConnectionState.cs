namespace Zu.ChromeDevTools.SmartCardEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Maps to |SCARD_*| connection state values.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ConnectionState
    {
        [JsonStringEnumMemberName("absent")]
        Absent,
        [JsonStringEnumMemberName("present")]
        Present,
        [JsonStringEnumMemberName("swallowed")]
        Swallowed,
        [JsonStringEnumMemberName("powered")]
        Powered,
        [JsonStringEnumMemberName("negotiable")]
        Negotiable,
        [JsonStringEnumMemberName("specific")]
        Specific,
    }
}
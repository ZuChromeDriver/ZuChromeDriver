namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Network level fetch failure reason.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ErrorReason
    {
        [JsonStringEnumMemberName("Failed")]
        Failed,
        [JsonStringEnumMemberName("Aborted")]
        Aborted,
        [JsonStringEnumMemberName("TimedOut")]
        TimedOut,
        [JsonStringEnumMemberName("AccessDenied")]
        AccessDenied,
        [JsonStringEnumMemberName("ConnectionClosed")]
        ConnectionClosed,
        [JsonStringEnumMemberName("ConnectionReset")]
        ConnectionReset,
        [JsonStringEnumMemberName("ConnectionRefused")]
        ConnectionRefused,
        [JsonStringEnumMemberName("ConnectionAborted")]
        ConnectionAborted,
        [JsonStringEnumMemberName("ConnectionFailed")]
        ConnectionFailed,
        [JsonStringEnumMemberName("NameNotResolved")]
        NameNotResolved,
        [JsonStringEnumMemberName("InternetDisconnected")]
        InternetDisconnected,
        [JsonStringEnumMemberName("AddressUnreachable")]
        AddressUnreachable,
        [JsonStringEnumMemberName("BlockedByClient")]
        BlockedByClient,
        [JsonStringEnumMemberName("BlockedByResponse")]
        BlockedByResponse,
    }
}
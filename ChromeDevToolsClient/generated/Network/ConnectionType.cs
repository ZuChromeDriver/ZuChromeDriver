namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// The underlying connection technology that the browser is supposedly using.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ConnectionType
    {
        [JsonStringEnumMemberName("none")]
        None,
        [JsonStringEnumMemberName("cellular2g")]
        Cellular2g,
        [JsonStringEnumMemberName("cellular3g")]
        Cellular3g,
        [JsonStringEnumMemberName("cellular4g")]
        Cellular4g,
        [JsonStringEnumMemberName("bluetooth")]
        Bluetooth,
        [JsonStringEnumMemberName("ethernet")]
        Ethernet,
        [JsonStringEnumMemberName("wifi")]
        Wifi,
        [JsonStringEnumMemberName("wimax")]
        Wimax,
        [JsonStringEnumMemberName("other")]
        Other,
    }
}
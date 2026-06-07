namespace Zu.ChromeDevTools.BluetoothEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Indicates the various types of GATT event.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GATTOperationType
    {
        [JsonStringEnumMemberName("connection")]
        Connection,
        [JsonStringEnumMemberName("discovery")]
        Discovery,
    }
}
namespace Zu.ChromeDevTools.BluetoothEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Indicates the various states of Central.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CentralState
    {
        [JsonStringEnumMemberName("absent")]
        Absent,
        [JsonStringEnumMemberName("powered-off")]
        PoweredOff,
        [JsonStringEnumMemberName("powered-on")]
        PoweredOn,
    }
}
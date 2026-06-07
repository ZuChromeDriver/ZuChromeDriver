namespace Zu.ChromeDevTools.BluetoothEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Indicates the various types of characteristic write.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CharacteristicWriteType
    {
        [JsonStringEnumMemberName("write-default-deprecated")]
        WriteDefaultDeprecated,
        [JsonStringEnumMemberName("write-with-response")]
        WriteWithResponse,
        [JsonStringEnumMemberName("write-without-response")]
        WriteWithoutResponse,
    }
}
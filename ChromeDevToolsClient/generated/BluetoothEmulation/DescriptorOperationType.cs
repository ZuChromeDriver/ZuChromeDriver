namespace Zu.ChromeDevTools.BluetoothEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Indicates the various types of descriptor operation.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DescriptorOperationType
    {
        [JsonStringEnumMemberName("read")]
        Read,
        [JsonStringEnumMemberName("write")]
        Write,
    }
}
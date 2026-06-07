namespace Zu.ChromeDevTools.BluetoothEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Indicates the various types of characteristic operation.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CharacteristicOperationType
    {
        [JsonStringEnumMemberName("read")]
        Read,
        [JsonStringEnumMemberName("write")]
        Write,
        [JsonStringEnumMemberName("subscribe-to-notifications")]
        SubscribeToNotifications,
        [JsonStringEnumMemberName("unsubscribe-from-notifications")]
        UnsubscribeFromNotifications,
    }
}
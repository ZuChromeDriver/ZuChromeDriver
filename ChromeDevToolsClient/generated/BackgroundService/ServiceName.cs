namespace Zu.ChromeDevTools.BackgroundService
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// The Background Service that will be associated with the commands/events.
    /// Every Background Service operates independently, but they share the same
    /// API.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ServiceName
    {
        [JsonStringEnumMemberName("backgroundFetch")]
        BackgroundFetch,
        [JsonStringEnumMemberName("backgroundSync")]
        BackgroundSync,
        [JsonStringEnumMemberName("pushMessaging")]
        PushMessaging,
        [JsonStringEnumMemberName("notifications")]
        Notifications,
        [JsonStringEnumMemberName("paymentHandler")]
        PaymentHandler,
        [JsonStringEnumMemberName("periodicBackgroundSync")]
        PeriodicBackgroundSync,
    }
}
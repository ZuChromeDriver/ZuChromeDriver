namespace Zu.ChromeDevTools.SmartCardEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Indicates what the reader should do with the card.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Disposition
    {
        [JsonStringEnumMemberName("leave-card")]
        LeaveCard,
        [JsonStringEnumMemberName("reset-card")]
        ResetCard,
        [JsonStringEnumMemberName("unpower-card")]
        UnpowerCard,
        [JsonStringEnumMemberName("eject-card")]
        EjectCard,
    }
}
namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Enum of auction events.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum InterestGroupAuctionEventType
    {
        [JsonStringEnumMemberName("started")]
        Started,
        [JsonStringEnumMemberName("configResolved")]
        ConfigResolved,
    }
}
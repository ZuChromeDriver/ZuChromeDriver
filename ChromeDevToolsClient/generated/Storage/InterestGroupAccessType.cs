namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Enum of interest group access types.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum InterestGroupAccessType
    {
        [JsonStringEnumMemberName("join")]
        Join,
        [JsonStringEnumMemberName("leave")]
        Leave,
        [JsonStringEnumMemberName("update")]
        Update,
        [JsonStringEnumMemberName("loaded")]
        Loaded,
        [JsonStringEnumMemberName("bid")]
        Bid,
        [JsonStringEnumMemberName("win")]
        Win,
        [JsonStringEnumMemberName("additionalBid")]
        AdditionalBid,
        [JsonStringEnumMemberName("additionalBidWin")]
        AdditionalBidWin,
        [JsonStringEnumMemberName("topLevelBid")]
        TopLevelBid,
        [JsonStringEnumMemberName("topLevelAdditionalBid")]
        TopLevelAdditionalBid,
        [JsonStringEnumMemberName("clear")]
        Clear,
    }
}
namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Enum of network fetches auctions can do.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum InterestGroupAuctionFetchType
    {
        [JsonStringEnumMemberName("bidderJs")]
        BidderJs,
        [JsonStringEnumMemberName("bidderWasm")]
        BidderWasm,
        [JsonStringEnumMemberName("sellerJs")]
        SellerJs,
        [JsonStringEnumMemberName("bidderTrustedSignals")]
        BidderTrustedSignals,
        [JsonStringEnumMemberName("sellerTrustedSignals")]
        SellerTrustedSignals,
    }
}
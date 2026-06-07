namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// One of the interest groups was accessed. Note that these events are global
    /// to all targets sharing an interest group store.
    /// </summary>
    public sealed class InterestGroupAccessedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the accessTime
        /// </summary>
        [JsonPropertyName("accessTime")]
        public double AccessTime
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the type
        /// </summary>
        [JsonPropertyName("type")]
        public InterestGroupAccessType Type
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the ownerOrigin
        /// </summary>
        [JsonPropertyName("ownerOrigin")]
        public string OwnerOrigin
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// For topLevelBid/topLevelAdditionalBid, and when appropriate,
        /// win and additionalBidWin
        /// </summary>
        [JsonPropertyName("componentSellerOrigin")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ComponentSellerOrigin
        {
            get;
            set;
        }
        /// <summary>
        /// For bid or somethingBid event, if done locally and not on a server.
        /// </summary>
        [JsonPropertyName("bid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? Bid
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the bidCurrency
        /// </summary>
        [JsonPropertyName("bidCurrency")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string BidCurrency
        {
            get;
            set;
        }
        /// <summary>
        /// For non-global events --- links to interestGroupAuctionEvent
        /// </summary>
        [JsonPropertyName("uniqueAuctionId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string UniqueAuctionId
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// An auction involving interest groups is taking place. These events are
    /// target-specific.
    /// </summary>
    public sealed class InterestGroupAuctionEventOccurredEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the eventTime
        /// </summary>
        [JsonPropertyName("eventTime")]
        public double EventTime
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the type
        /// </summary>
        [JsonPropertyName("type")]
        public InterestGroupAuctionEventType Type
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the uniqueAuctionId
        /// </summary>
        [JsonPropertyName("uniqueAuctionId")]
        public string UniqueAuctionId
        {
            get;
            set;
        }
        /// <summary>
        /// Set for child auctions.
        /// </summary>
        [JsonPropertyName("parentAuctionId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ParentAuctionId
        {
            get;
            set;
        }
        /// <summary>
        /// Set for started and configResolved
        /// </summary>
        [JsonPropertyName("auctionConfig")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public object AuctionConfig
        {
            get;
            set;
        }
    }
}
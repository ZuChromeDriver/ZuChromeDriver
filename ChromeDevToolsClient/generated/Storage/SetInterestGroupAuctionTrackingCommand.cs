namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Enables/Disables issuing of interestGroupAuctionEventOccurred and
    /// interestGroupAuctionNetworkRequestCreated.
    /// </summary>
    public sealed class SetInterestGroupAuctionTrackingCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Storage.setInterestGroupAuctionTracking";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the enable
        /// </summary>
        [JsonPropertyName("enable")]
        public bool Enable
        {
            get;
            set;
        }
    }

    public sealed class SetInterestGroupAuctionTrackingCommandResponse : ICommandResponse<SetInterestGroupAuctionTrackingCommand>
    {
    }
}
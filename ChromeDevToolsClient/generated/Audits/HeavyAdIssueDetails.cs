namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class HeavyAdIssueDetails
    {
        /// <summary>
        /// The resolution status, either blocking the content or warning.
        ///</summary>
        [JsonPropertyName("resolution")]
        public HeavyAdResolutionStatus Resolution
        {
            get;
            set;
        }
        /// <summary>
        /// The reason the ad was blocked, total network or cpu or peak cpu.
        ///</summary>
        [JsonPropertyName("reason")]
        public HeavyAdReason Reason
        {
            get;
            set;
        }
        /// <summary>
        /// The frame that was blocked.
        ///</summary>
        [JsonPropertyName("frame")]
        public AffectedFrame Frame
        {
            get;
            set;
        }
    }
}
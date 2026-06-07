namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class OriginTrial
    {
        /// <summary>
        /// Gets or sets the trialName
        /// </summary>
        [JsonPropertyName("trialName")]
        public string TrialName
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the status
        /// </summary>
        [JsonPropertyName("status")]
        public OriginTrialStatus Status
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the tokensWithStatus
        /// </summary>
        [JsonPropertyName("tokensWithStatus")]
        public OriginTrialTokenWithStatus[] TokensWithStatus
        {
            get;
            set;
        }
    }
}
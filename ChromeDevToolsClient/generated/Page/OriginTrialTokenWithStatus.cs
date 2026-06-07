namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class OriginTrialTokenWithStatus
    {
        /// <summary>
        /// Gets or sets the rawTokenText
        /// </summary>
        [JsonPropertyName("rawTokenText")]
        public string RawTokenText
        {
            get;
            set;
        }
        /// <summary>
        /// `parsedToken` is present only when the token is extractable and
        /// parsable.
        ///</summary>
        [JsonPropertyName("parsedToken")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public OriginTrialToken ParsedToken
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the status
        /// </summary>
        [JsonPropertyName("status")]
        public OriginTrialTokenStatus Status
        {
            get;
            set;
        }
    }
}
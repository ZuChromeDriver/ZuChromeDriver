namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class UnencodedDigestIssueDetails
    {
        /// <summary>
        /// Gets or sets the error
        /// </summary>
        [JsonPropertyName("error")]
        public UnencodedDigestError Error
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the request
        /// </summary>
        [JsonPropertyName("request")]
        public AffectedRequest Request
        {
            get;
            set;
        }
    }
}
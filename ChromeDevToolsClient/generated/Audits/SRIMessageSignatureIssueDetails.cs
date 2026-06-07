namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class SRIMessageSignatureIssueDetails
    {
        /// <summary>
        /// Gets or sets the error
        /// </summary>
        [JsonPropertyName("error")]
        public SRIMessageSignatureError Error
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the signatureBase
        /// </summary>
        [JsonPropertyName("signatureBase")]
        public string SignatureBase
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the integrityAssertions
        /// </summary>
        [JsonPropertyName("integrityAssertions")]
        public string[] IntegrityAssertions
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
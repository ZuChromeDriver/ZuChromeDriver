namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Details for a CORS related issue, e.g. a warning or error related to
    /// CORS RFC1918 enforcement.
    /// </summary>
    public sealed class CorsIssueDetails
    {
        /// <summary>
        /// Gets or sets the corsErrorStatus
        /// </summary>
        [JsonPropertyName("corsErrorStatus")]
        public Network.CorsErrorStatus CorsErrorStatus
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the isWarning
        /// </summary>
        [JsonPropertyName("isWarning")]
        public bool IsWarning
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
        /// <summary>
        /// Gets or sets the location
        /// </summary>
        [JsonPropertyName("location")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public SourceCodeLocation Location
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the initiatorOrigin
        /// </summary>
        [JsonPropertyName("initiatorOrigin")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string InitiatorOrigin
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the resourceIPAddressSpace
        /// </summary>
        [JsonPropertyName("resourceIPAddressSpace")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Network.IPAddressSpace? ResourceIPAddressSpace
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the clientSecurityState
        /// </summary>
        [JsonPropertyName("clientSecurityState")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Network.ClientSecurityState ClientSecurityState
        {
            get;
            set;
        }
    }
}
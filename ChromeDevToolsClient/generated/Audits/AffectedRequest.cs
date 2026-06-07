namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Information about a request that is affected by an inspector issue.
    /// </summary>
    public sealed class AffectedRequest
    {
        /// <summary>
        /// The unique request id.
        ///</summary>
        [JsonPropertyName("requestId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string RequestId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the url
        /// </summary>
        [JsonPropertyName("url")]
        public string Url
        {
            get;
            set;
        }
    }
}
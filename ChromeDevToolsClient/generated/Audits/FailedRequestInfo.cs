namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class FailedRequestInfo
    {
        /// <summary>
        /// The URL that failed to load.
        ///</summary>
        [JsonPropertyName("url")]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// The failure message for the failed request.
        ///</summary>
        [JsonPropertyName("failureMessage")]
        public string FailureMessage
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the requestId
        /// </summary>
        [JsonPropertyName("requestId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string RequestId
        {
            get;
            set;
        }
    }
}
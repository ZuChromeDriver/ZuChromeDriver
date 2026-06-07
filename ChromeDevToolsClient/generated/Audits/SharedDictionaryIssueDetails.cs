namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class SharedDictionaryIssueDetails
    {
        /// <summary>
        /// Gets or sets the sharedDictionaryError
        /// </summary>
        [JsonPropertyName("sharedDictionaryError")]
        public SharedDictionaryError SharedDictionaryError
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
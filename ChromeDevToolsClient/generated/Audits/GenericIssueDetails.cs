namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Depending on the concrete errorType, different properties are set.
    /// </summary>
    public sealed class GenericIssueDetails
    {
        /// <summary>
        /// Issues with the same errorType are aggregated in the frontend.
        ///</summary>
        [JsonPropertyName("errorType")]
        public GenericIssueErrorType ErrorType
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the frameId
        /// </summary>
        [JsonPropertyName("frameId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string FrameId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the violatingNodeId
        /// </summary>
        [JsonPropertyName("violatingNodeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? ViolatingNodeId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the violatingNodeAttribute
        /// </summary>
        [JsonPropertyName("violatingNodeAttribute")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ViolatingNodeAttribute
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the request
        /// </summary>
        [JsonPropertyName("request")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public AffectedRequest Request
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// This issue warns about uses of APIs that may be considered misuse to
    /// re-identify users.
    /// </summary>
    public sealed class UserReidentificationIssueDetails
    {
        /// <summary>
        /// Gets or sets the type
        /// </summary>
        [JsonPropertyName("type")]
        public UserReidentificationIssueType Type
        {
            get;
            set;
        }
        /// <summary>
        /// Applies to BlockedFrameNavigation and BlockedSubresource issue types.
        ///</summary>
        [JsonPropertyName("request")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public AffectedRequest Request
        {
            get;
            set;
        }
        /// <summary>
        /// Applies to NoisedCanvasReadback issue type.
        ///</summary>
        [JsonPropertyName("sourceCodeLocation")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public SourceCodeLocation SourceCodeLocation
        {
            get;
            set;
        }
    }
}
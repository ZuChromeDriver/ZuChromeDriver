namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Details for issues about documents in Quirks Mode
    /// or Limited Quirks Mode that affects page layouting.
    /// </summary>
    public sealed class QuirksModeIssueDetails
    {
        /// <summary>
        /// If false, it means the document's mode is "quirks"
        /// instead of "limited-quirks".
        ///</summary>
        [JsonPropertyName("isLimitedQuirksMode")]
        public bool IsLimitedQuirksMode
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the documentNodeId
        /// </summary>
        [JsonPropertyName("documentNodeId")]
        public long DocumentNodeId
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
        /// <summary>
        /// Gets or sets the frameId
        /// </summary>
        [JsonPropertyName("frameId")]
        public string FrameId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the loaderId
        /// </summary>
        [JsonPropertyName("loaderId")]
        public string LoaderId
        {
            get;
            set;
        }
    }
}
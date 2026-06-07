namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class BackForwardCacheNotRestoredExplanation
    {
        /// <summary>
        /// Type of the reason
        ///</summary>
        [JsonPropertyName("type")]
        public BackForwardCacheNotRestoredReasonType Type
        {
            get;
            set;
        }
        /// <summary>
        /// Not restored reason
        ///</summary>
        [JsonPropertyName("reason")]
        public BackForwardCacheNotRestoredReason Reason
        {
            get;
            set;
        }
        /// <summary>
        /// Context associated with the reason. The meaning of this context is
        /// dependent on the reason:
        /// - EmbedderExtensionSentMessageToCachedFrame: the extension ID.
        ///</summary>
        [JsonPropertyName("context")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Context
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the details
        /// </summary>
        [JsonPropertyName("details")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public BackForwardCacheBlockingDetails[] Details
        {
            get;
            set;
        }
    }
}
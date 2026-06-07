namespace Zu.ChromeDevTools.Security
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Information about insecure content on the page.
    /// </summary>
    public sealed class InsecureContentStatus
    {
        /// <summary>
        /// Always false.
        ///</summary>
        [JsonPropertyName("ranMixedContent")]
        public bool RanMixedContent
        {
            get;
            set;
        }
        /// <summary>
        /// Always false.
        ///</summary>
        [JsonPropertyName("displayedMixedContent")]
        public bool DisplayedMixedContent
        {
            get;
            set;
        }
        /// <summary>
        /// Always false.
        ///</summary>
        [JsonPropertyName("containedMixedForm")]
        public bool ContainedMixedForm
        {
            get;
            set;
        }
        /// <summary>
        /// Always false.
        ///</summary>
        [JsonPropertyName("ranContentWithCertErrors")]
        public bool RanContentWithCertErrors
        {
            get;
            set;
        }
        /// <summary>
        /// Always false.
        ///</summary>
        [JsonPropertyName("displayedContentWithCertErrors")]
        public bool DisplayedContentWithCertErrors
        {
            get;
            set;
        }
        /// <summary>
        /// Always set to unknown.
        ///</summary>
        [JsonPropertyName("ranInsecureContentStyle")]
        public SecurityState RanInsecureContentStyle
        {
            get;
            set;
        }
        /// <summary>
        /// Always set to unknown.
        ///</summary>
        [JsonPropertyName("displayedInsecureContentStyle")]
        public SecurityState DisplayedInsecureContentStyle
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.Security
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// The security state of the page changed. No longer being sent.
    /// </summary>
    public sealed class SecurityStateChangedEvent : IEvent
    {
        /// <summary>
        /// Security state.
        /// </summary>
        [JsonPropertyName("securityState")]
        public SecurityState SecurityState
        {
            get;
            set;
        }
        /// <summary>
        /// True if the page was loaded over cryptographic transport such as HTTPS.
        /// </summary>
        [JsonPropertyName("schemeIsCryptographic")]
        public bool SchemeIsCryptographic
        {
            get;
            set;
        }
        /// <summary>
        /// Previously a list of explanations for the security state. Now always
        /// empty.
        /// </summary>
        [JsonPropertyName("explanations")]
        public SecurityStateExplanation[] Explanations
        {
            get;
            set;
        }
        /// <summary>
        /// Information about insecure content on the page.
        /// </summary>
        [JsonPropertyName("insecureContentStatus")]
        public InsecureContentStatus InsecureContentStatus
        {
            get;
            set;
        }
        /// <summary>
        /// Overrides user-visible description of the state. Always omitted.
        /// </summary>
        [JsonPropertyName("summary")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Summary
        {
            get;
            set;
        }
    }
}
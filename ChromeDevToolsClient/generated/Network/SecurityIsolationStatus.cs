namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class SecurityIsolationStatus
    {
        /// <summary>
        /// Gets or sets the coop
        /// </summary>
        [JsonPropertyName("coop")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CrossOriginOpenerPolicyStatus Coop
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the coep
        /// </summary>
        [JsonPropertyName("coep")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CrossOriginEmbedderPolicyStatus Coep
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the csp
        /// </summary>
        [JsonPropertyName("csp")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ContentSecurityPolicyStatus[] Csp
        {
            get;
            set;
        }
    }
}
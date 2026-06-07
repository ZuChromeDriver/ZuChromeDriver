namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class ContentSecurityPolicyStatus
    {
        /// <summary>
        /// Gets or sets the effectiveDirectives
        /// </summary>
        [JsonPropertyName("effectiveDirectives")]
        public string EffectiveDirectives
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the isEnforced
        /// </summary>
        [JsonPropertyName("isEnforced")]
        public bool IsEnforced
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the source
        /// </summary>
        [JsonPropertyName("source")]
        public ContentSecurityPolicySource Source
        {
            get;
            set;
        }
    }
}
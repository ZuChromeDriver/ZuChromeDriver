namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class ClientSecurityState
    {
        /// <summary>
        /// Gets or sets the initiatorIsSecureContext
        /// </summary>
        [JsonPropertyName("initiatorIsSecureContext")]
        public bool InitiatorIsSecureContext
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the initiatorIPAddressSpace
        /// </summary>
        [JsonPropertyName("initiatorIPAddressSpace")]
        public IPAddressSpace InitiatorIPAddressSpace
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the localNetworkAccessRequestPolicy
        /// </summary>
        [JsonPropertyName("localNetworkAccessRequestPolicy")]
        public LocalNetworkAccessRequestPolicy LocalNetworkAccessRequestPolicy
        {
            get;
            set;
        }
    }
}
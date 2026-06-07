namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Pair of issuer origin and number of available (signed, but not used) Trust
    /// Tokens from that issuer.
    /// </summary>
    public sealed class TrustTokens
    {
        /// <summary>
        /// Gets or sets the issuerOrigin
        /// </summary>
        [JsonPropertyName("issuerOrigin")]
        public string IssuerOrigin
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the count
        /// </summary>
        [JsonPropertyName("count")]
        public double Count
        {
            get;
            set;
        }
    }
}
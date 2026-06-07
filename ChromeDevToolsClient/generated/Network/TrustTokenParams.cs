namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Determines what type of Trust Token operation is executed and
    /// depending on the type, some additional parameters. The values
    /// are specified in third_party/blink/renderer/core/fetch/trust_token.idl.
    /// </summary>
    public sealed class TrustTokenParams
    {
        /// <summary>
        /// Gets or sets the operation
        /// </summary>
        [JsonPropertyName("operation")]
        public TrustTokenOperationType Operation
        {
            get;
            set;
        }
        /// <summary>
        /// Only set for "token-redemption" operation and determine whether
        /// to request a fresh SRR or use a still valid cached SRR.
        ///</summary>
        [JsonPropertyName("refreshPolicy")]
        public string RefreshPolicy
        {
            get;
            set;
        }
        /// <summary>
        /// Origins of issuers from whom to request tokens or redemption
        /// records.
        ///</summary>
        [JsonPropertyName("issuers")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string[] Issuers
        {
            get;
            set;
        }
    }
}
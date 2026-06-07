namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired exactly once for each Trust Token operation. Depending on
    /// the type of the operation and whether the operation succeeded or
    /// failed, the event is fired before the corresponding request was sent
    /// or after the response was received.
    /// </summary>
    public sealed class TrustTokenOperationDoneEvent : IEvent
    {
        /// <summary>
        /// Detailed success or error status of the operation.
        /// 'AlreadyExists' also signifies a successful operation, as the result
        /// of the operation already exists und thus, the operation was abort
        /// preemptively (e.g. a cache hit).
        /// </summary>
        [JsonPropertyName("status")]
        public string Status
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the type
        /// </summary>
        [JsonPropertyName("type")]
        public TrustTokenOperationType Type
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the requestId
        /// </summary>
        [JsonPropertyName("requestId")]
        public string RequestId
        {
            get;
            set;
        }
        /// <summary>
        /// Top level origin. The context in which the operation was attempted.
        /// </summary>
        [JsonPropertyName("topLevelOrigin")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string TopLevelOrigin
        {
            get;
            set;
        }
        /// <summary>
        /// Origin of the issuer in case of a "Issuance" or "Redemption" operation.
        /// </summary>
        [JsonPropertyName("issuerOrigin")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string IssuerOrigin
        {
            get;
            set;
        }
        /// <summary>
        /// The number of obtained Trust Tokens on a successful "Issuance" operation.
        /// </summary>
        [JsonPropertyName("issuedTokenCount")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? IssuedTokenCount
        {
            get;
            set;
        }
    }
}
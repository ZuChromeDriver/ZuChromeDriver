namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when a signed exchange was received over the network
    /// </summary>
    public sealed class SignedExchangeReceivedEvent : IEvent
    {
        /// <summary>
        /// Request identifier.
        /// </summary>
        [JsonPropertyName("requestId")]
        public string RequestId
        {
            get;
            set;
        }
        /// <summary>
        /// Information about the signed exchange response.
        /// </summary>
        [JsonPropertyName("info")]
        public SignedExchangeInfo Info
        {
            get;
            set;
        }
    }
}
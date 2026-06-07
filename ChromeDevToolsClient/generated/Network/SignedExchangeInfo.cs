namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Information about a signed exchange response.
    /// </summary>
    public sealed class SignedExchangeInfo
    {
        /// <summary>
        /// The outer response of signed HTTP exchange which was received from network.
        ///</summary>
        [JsonPropertyName("outerResponse")]
        public Response OuterResponse
        {
            get;
            set;
        }
        /// <summary>
        /// Whether network response for the signed exchange was accompanied by
        /// extra headers.
        ///</summary>
        [JsonPropertyName("hasExtraInfo")]
        public bool HasExtraInfo
        {
            get;
            set;
        }
        /// <summary>
        /// Information about the signed exchange header.
        ///</summary>
        [JsonPropertyName("header")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public SignedExchangeHeader Header
        {
            get;
            set;
        }
        /// <summary>
        /// Security details for the signed exchange header.
        ///</summary>
        [JsonPropertyName("securityDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public SecurityDetails SecurityDetails
        {
            get;
            set;
        }
        /// <summary>
        /// Errors occurred while handling the signed exchange.
        ///</summary>
        [JsonPropertyName("errors")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public SignedExchangeError[] Errors
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Information about a signed exchange response.
    /// </summary>
    public sealed class SignedExchangeError
    {
        /// <summary>
        /// Error message.
        ///</summary>
        [JsonPropertyName("message")]
        public string Message
        {
            get;
            set;
        }
        /// <summary>
        /// The index of the signature which caused the error.
        ///</summary>
        [JsonPropertyName("signatureIndex")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? SignatureIndex
        {
            get;
            set;
        }
        /// <summary>
        /// The field which caused the error.
        ///</summary>
        [JsonPropertyName("errorField")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public SignedExchangeErrorField? ErrorField
        {
            get;
            set;
        }
    }
}
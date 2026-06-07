namespace Zu.ChromeDevTools.Autofill
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class CreditCard
    {
        /// <summary>
        /// 16-digit credit card number.
        ///</summary>
        [JsonPropertyName("number")]
        public string Number
        {
            get;
            set;
        }
        /// <summary>
        /// Name of the credit card owner.
        ///</summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// 2-digit expiry month.
        ///</summary>
        [JsonPropertyName("expiryMonth")]
        public string ExpiryMonth
        {
            get;
            set;
        }
        /// <summary>
        /// 4-digit expiry year.
        ///</summary>
        [JsonPropertyName("expiryYear")]
        public string ExpiryYear
        {
            get;
            set;
        }
        /// <summary>
        /// 3-digit card verification code.
        ///</summary>
        [JsonPropertyName("cvc")]
        public string Cvc
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.FedCm
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Corresponds to IdentityRequestAccount
    /// </summary>
    public sealed class Account
    {
        /// <summary>
        /// Gets or sets the accountId
        /// </summary>
        [JsonPropertyName("accountId")]
        public string AccountId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the email
        /// </summary>
        [JsonPropertyName("email")]
        public string Email
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the givenName
        /// </summary>
        [JsonPropertyName("givenName")]
        public string GivenName
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the pictureUrl
        /// </summary>
        [JsonPropertyName("pictureUrl")]
        public string PictureUrl
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the idpConfigUrl
        /// </summary>
        [JsonPropertyName("idpConfigUrl")]
        public string IdpConfigUrl
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the idpLoginUrl
        /// </summary>
        [JsonPropertyName("idpLoginUrl")]
        public string IdpLoginUrl
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the loginState
        /// </summary>
        [JsonPropertyName("loginState")]
        public LoginState LoginState
        {
            get;
            set;
        }
        /// <summary>
        /// These two are only set if the loginState is signUp
        ///</summary>
        [JsonPropertyName("termsOfServiceUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string TermsOfServiceUrl
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the privacyPolicyUrl
        /// </summary>
        [JsonPropertyName("privacyPolicyUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string PrivacyPolicyUrl
        {
            get;
            set;
        }
    }
}
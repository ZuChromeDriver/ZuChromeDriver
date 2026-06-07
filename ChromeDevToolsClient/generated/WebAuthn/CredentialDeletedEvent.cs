namespace Zu.ChromeDevTools.WebAuthn
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Triggered when a credential is deleted, e.g. through
    /// PublicKeyCredential.signalUnknownCredential().
    /// </summary>
    public sealed class CredentialDeletedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the authenticatorId
        /// </summary>
        [JsonPropertyName("authenticatorId")]
        public string AuthenticatorId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the credentialId
        /// </summary>
        [JsonPropertyName("credentialId")]
        public string CredentialId
        {
            get;
            set;
        }
    }
}
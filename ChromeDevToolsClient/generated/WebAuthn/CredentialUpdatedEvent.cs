namespace Zu.ChromeDevTools.WebAuthn
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Triggered when a credential is updated, e.g. through
    /// PublicKeyCredential.signalCurrentUserDetails().
    /// </summary>
    public sealed class CredentialUpdatedEvent : IEvent
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
        /// Gets or sets the credential
        /// </summary>
        [JsonPropertyName("credential")]
        public Credential Credential
        {
            get;
            set;
        }
    }
}
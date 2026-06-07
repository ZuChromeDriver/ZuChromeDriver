namespace Zu.ChromeDevTools.WebAuthn
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Triggered when a credential is used in a webauthn assertion.
    /// </summary>
    public sealed class CredentialAssertedEvent : IEvent
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
namespace Zu.ChromeDevTools.ServiceWorker
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// ServiceWorker registration.
    /// </summary>
    public sealed class ServiceWorkerRegistration
    {
        /// <summary>
        /// Gets or sets the registrationId
        /// </summary>
        [JsonPropertyName("registrationId")]
        public string RegistrationId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the scopeURL
        /// </summary>
        [JsonPropertyName("scopeURL")]
        public string ScopeURL
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the isDeleted
        /// </summary>
        [JsonPropertyName("isDeleted")]
        public bool IsDeleted
        {
            get;
            set;
        }
    }
}
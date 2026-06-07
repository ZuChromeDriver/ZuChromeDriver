namespace Zu.ChromeDevTools.ServiceWorker
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// ServiceWorker error message.
    /// </summary>
    public sealed class ServiceWorkerErrorMessage
    {
        /// <summary>
        /// Gets or sets the errorMessage
        /// </summary>
        [JsonPropertyName("errorMessage")]
        public string ErrorMessage
        {
            get;
            set;
        }
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
        /// Gets or sets the versionId
        /// </summary>
        [JsonPropertyName("versionId")]
        public string VersionId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the sourceURL
        /// </summary>
        [JsonPropertyName("sourceURL")]
        public string SourceURL
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the lineNumber
        /// </summary>
        [JsonPropertyName("lineNumber")]
        public long LineNumber
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the columnNumber
        /// </summary>
        [JsonPropertyName("columnNumber")]
        public long ColumnNumber
        {
            get;
            set;
        }
    }
}
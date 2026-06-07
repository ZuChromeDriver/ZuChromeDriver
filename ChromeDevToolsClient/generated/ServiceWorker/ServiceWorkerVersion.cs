namespace Zu.ChromeDevTools.ServiceWorker
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// ServiceWorker version.
    /// </summary>
    public sealed class ServiceWorkerVersion
    {
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
        /// Gets or sets the registrationId
        /// </summary>
        [JsonPropertyName("registrationId")]
        public string RegistrationId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the scriptURL
        /// </summary>
        [JsonPropertyName("scriptURL")]
        public string ScriptURL
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the runningStatus
        /// </summary>
        [JsonPropertyName("runningStatus")]
        public ServiceWorkerVersionRunningStatus RunningStatus
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the status
        /// </summary>
        [JsonPropertyName("status")]
        public ServiceWorkerVersionStatus Status
        {
            get;
            set;
        }
        /// <summary>
        /// The Last-Modified header value of the main script.
        ///</summary>
        [JsonPropertyName("scriptLastModified")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? ScriptLastModified
        {
            get;
            set;
        }
        /// <summary>
        /// The time at which the response headers of the main script were received from the server.
        /// For cached script it is the last time the cache entry was validated.
        ///</summary>
        [JsonPropertyName("scriptResponseTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? ScriptResponseTime
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the controlledClients
        /// </summary>
        [JsonPropertyName("controlledClients")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string[] ControlledClients
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the targetId
        /// </summary>
        [JsonPropertyName("targetId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string TargetId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the routerRules
        /// </summary>
        [JsonPropertyName("routerRules")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string RouterRules
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.BackgroundService
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class BackgroundServiceEvent
    {
        /// <summary>
        /// Timestamp of the event (in seconds).
        ///</summary>
        [JsonPropertyName("timestamp")]
        public double Timestamp
        {
            get;
            set;
        }
        /// <summary>
        /// The origin this event belongs to.
        ///</summary>
        [JsonPropertyName("origin")]
        public string Origin
        {
            get;
            set;
        }
        /// <summary>
        /// The Service Worker ID that initiated the event.
        ///</summary>
        [JsonPropertyName("serviceWorkerRegistrationId")]
        public string ServiceWorkerRegistrationId
        {
            get;
            set;
        }
        /// <summary>
        /// The Background Service this event belongs to.
        ///</summary>
        [JsonPropertyName("service")]
        public ServiceName Service
        {
            get;
            set;
        }
        /// <summary>
        /// A description of the event.
        ///</summary>
        [JsonPropertyName("eventName")]
        public string EventName
        {
            get;
            set;
        }
        /// <summary>
        /// An identifier that groups related events together.
        ///</summary>
        [JsonPropertyName("instanceId")]
        public string InstanceId
        {
            get;
            set;
        }
        /// <summary>
        /// A list of event-specific information.
        ///</summary>
        [JsonPropertyName("eventMetadata")]
        public EventMetadata[] EventMetadata
        {
            get;
            set;
        }
        /// <summary>
        /// Storage key this event belongs to.
        ///</summary>
        [JsonPropertyName("storageKey")]
        public string StorageKey
        {
            get;
            set;
        }
    }
}
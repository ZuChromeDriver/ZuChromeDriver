namespace Zu.ChromeDevTools.ServiceWorker
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class WorkerRegistrationUpdatedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the registrations
        /// </summary>
        [JsonPropertyName("registrations")]
        public ServiceWorkerRegistration[] Registrations
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.ServiceWorker
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class WorkerVersionUpdatedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the versions
        /// </summary>
        [JsonPropertyName("versions")]
        public ServiceWorkerVersion[] Versions
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.ServiceWorker
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class WorkerErrorReportedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the errorMessage
        /// </summary>
        [JsonPropertyName("errorMessage")]
        public ServiceWorkerErrorMessage ErrorMessage
        {
            get;
            set;
        }
    }
}
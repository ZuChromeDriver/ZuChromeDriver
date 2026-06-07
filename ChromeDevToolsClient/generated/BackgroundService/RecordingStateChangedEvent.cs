namespace Zu.ChromeDevTools.BackgroundService
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Called when the recording state for the service has been updated.
    /// </summary>
    public sealed class RecordingStateChangedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the isRecording
        /// </summary>
        [JsonPropertyName("isRecording")]
        public bool IsRecording
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the service
        /// </summary>
        [JsonPropertyName("service")]
        public ServiceName Service
        {
            get;
            set;
        }
    }
}
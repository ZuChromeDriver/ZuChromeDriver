namespace Zu.ChromeDevTools.BackgroundService
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Called with all existing backgroundServiceEvents when enabled, and all new
    /// events afterwards if enabled and recording.
    /// </summary>
    public sealed class BackgroundServiceEventReceivedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the backgroundServiceEvent
        /// </summary>
        [JsonPropertyName("backgroundServiceEvent")]
        public BackgroundServiceEvent BackgroundServiceEvent
        {
            get;
            set;
        }
    }
}
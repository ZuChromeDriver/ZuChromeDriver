namespace Zu.ChromeDevTools.Log
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Issued when new message was logged.
    /// </summary>
    public sealed class EntryAddedEvent : IEvent
    {
        /// <summary>
        /// The entry.
        /// </summary>
        [JsonPropertyName("entry")]
        public LogEntry Entry
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.Console
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Issued when new console message is added.
    /// </summary>
    public sealed class MessageAddedEvent : IEvent
    {
        /// <summary>
        /// Console message that has been added.
        /// </summary>
        [JsonPropertyName("message")]
        public ConsoleMessage Message
        {
            get;
            set;
        }
    }
}
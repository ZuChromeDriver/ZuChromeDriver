namespace Zu.ChromeDevTools.Media
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Send a list of any messages that need to be delivered.
    /// </summary>
    public sealed class PlayerMessagesLoggedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the playerId
        /// </summary>
        [JsonPropertyName("playerId")]
        public string PlayerId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the messages
        /// </summary>
        [JsonPropertyName("messages")]
        public PlayerMessage[] Messages
        {
            get;
            set;
        }
    }
}
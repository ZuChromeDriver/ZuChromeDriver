namespace Zu.ChromeDevTools.Media
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Send a list of any errors that need to be delivered.
    /// </summary>
    public sealed class PlayerErrorsRaisedEvent : IEvent
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
        /// Gets or sets the errors
        /// </summary>
        [JsonPropertyName("errors")]
        public PlayerError[] Errors
        {
            get;
            set;
        }
    }
}
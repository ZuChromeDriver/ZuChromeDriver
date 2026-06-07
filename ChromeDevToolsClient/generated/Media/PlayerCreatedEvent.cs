namespace Zu.ChromeDevTools.Media
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Called whenever a player is created, or when a new agent joins and receives
    /// a list of active players. If an agent is restored, it will receive one
    /// event for each active player.
    /// </summary>
    public sealed class PlayerCreatedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the player
        /// </summary>
        [JsonPropertyName("player")]
        public Player Player
        {
            get;
            set;
        }
    }
}
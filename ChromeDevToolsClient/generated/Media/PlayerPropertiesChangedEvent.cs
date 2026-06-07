namespace Zu.ChromeDevTools.Media
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// This can be called multiple times, and can be used to set / override /
    /// remove player properties. A null propValue indicates removal.
    /// </summary>
    public sealed class PlayerPropertiesChangedEvent : IEvent
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
        /// Gets or sets the properties
        /// </summary>
        [JsonPropertyName("properties")]
        public PlayerProperty[] Properties
        {
            get;
            set;
        }
    }
}
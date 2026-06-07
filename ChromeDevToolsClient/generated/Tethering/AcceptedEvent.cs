namespace Zu.ChromeDevTools.Tethering
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Informs that port was successfully bound and got a specified connection id.
    /// </summary>
    public sealed class AcceptedEvent : IEvent
    {
        /// <summary>
        /// Port number that was successfully bound.
        /// </summary>
        [JsonPropertyName("port")]
        public long Port
        {
            get;
            set;
        }
        /// <summary>
        /// Connection id to be used.
        /// </summary>
        [JsonPropertyName("connectionId")]
        public string ConnectionId
        {
            get;
            set;
        }
    }
}
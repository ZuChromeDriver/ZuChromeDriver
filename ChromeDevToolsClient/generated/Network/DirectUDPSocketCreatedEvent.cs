namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired upon direct_socket.UDPSocket creation.
    /// </summary>
    public sealed class DirectUDPSocketCreatedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        [JsonPropertyName("identifier")]
        public string Identifier
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the options
        /// </summary>
        [JsonPropertyName("options")]
        public DirectUDPSocketOptions Options
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the timestamp
        /// </summary>
        [JsonPropertyName("timestamp")]
        public double Timestamp
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the initiator
        /// </summary>
        [JsonPropertyName("initiator")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Initiator Initiator
        {
            get;
            set;
        }
    }
}
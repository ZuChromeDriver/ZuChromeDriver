namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired upon direct_socket.TCPSocket creation.
    /// </summary>
    public sealed class DirectTCPSocketCreatedEvent : IEvent
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
        /// Gets or sets the remoteAddr
        /// </summary>
        [JsonPropertyName("remoteAddr")]
        public string RemoteAddr
        {
            get;
            set;
        }
        /// <summary>
        /// Unsigned int 16.
        /// </summary>
        [JsonPropertyName("remotePort")]
        public long RemotePort
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the options
        /// </summary>
        [JsonPropertyName("options")]
        public DirectTCPSocketOptions Options
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
namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when direct_socket.TCPSocket connection is opened.
    /// </summary>
    public sealed class DirectTCPSocketOpenedEvent : IEvent
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
        /// Expected to be unsigned integer.
        /// </summary>
        [JsonPropertyName("remotePort")]
        public long RemotePort
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
        /// Gets or sets the localAddr
        /// </summary>
        [JsonPropertyName("localAddr")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string LocalAddr
        {
            get;
            set;
        }
        /// <summary>
        /// Expected to be unsigned integer.
        /// </summary>
        [JsonPropertyName("localPort")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? LocalPort
        {
            get;
            set;
        }
    }
}
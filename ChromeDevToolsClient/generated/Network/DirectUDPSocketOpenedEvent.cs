namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when direct_socket.UDPSocket connection is opened.
    /// </summary>
    public sealed class DirectUDPSocketOpenedEvent : IEvent
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
        /// Gets or sets the localAddr
        /// </summary>
        [JsonPropertyName("localAddr")]
        public string LocalAddr
        {
            get;
            set;
        }
        /// <summary>
        /// Expected to be unsigned integer.
        /// </summary>
        [JsonPropertyName("localPort")]
        public long LocalPort
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
        /// Gets or sets the remoteAddr
        /// </summary>
        [JsonPropertyName("remoteAddr")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string RemoteAddr
        {
            get;
            set;
        }
        /// <summary>
        /// Expected to be unsigned integer.
        /// </summary>
        [JsonPropertyName("remotePort")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? RemotePort
        {
            get;
            set;
        }
    }
}
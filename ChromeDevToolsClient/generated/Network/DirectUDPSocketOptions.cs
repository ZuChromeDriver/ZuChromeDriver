namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class DirectUDPSocketOptions
    {
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
        /// Unsigned int 16.
        ///</summary>
        [JsonPropertyName("remotePort")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? RemotePort
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
        /// Unsigned int 16.
        ///</summary>
        [JsonPropertyName("localPort")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? LocalPort
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the dnsQueryType
        /// </summary>
        [JsonPropertyName("dnsQueryType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DirectSocketDnsQueryType? DnsQueryType
        {
            get;
            set;
        }
        /// <summary>
        /// Expected to be unsigned integer.
        ///</summary>
        [JsonPropertyName("sendBufferSize")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? SendBufferSize
        {
            get;
            set;
        }
        /// <summary>
        /// Expected to be unsigned integer.
        ///</summary>
        [JsonPropertyName("receiveBufferSize")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? ReceiveBufferSize
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the multicastLoopback
        /// </summary>
        [JsonPropertyName("multicastLoopback")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? MulticastLoopback
        {
            get;
            set;
        }
        /// <summary>
        /// Unsigned int 8.
        ///</summary>
        [JsonPropertyName("multicastTimeToLive")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? MulticastTimeToLive
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the multicastAllowAddressSharing
        /// </summary>
        [JsonPropertyName("multicastAllowAddressSharing")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? MulticastAllowAddressSharing
        {
            get;
            set;
        }
    }
}
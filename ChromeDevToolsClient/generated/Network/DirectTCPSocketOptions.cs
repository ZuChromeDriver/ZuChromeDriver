namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class DirectTCPSocketOptions
    {
        /// <summary>
        /// TCP_NODELAY option
        ///</summary>
        [JsonPropertyName("noDelay")]
        public bool NoDelay
        {
            get;
            set;
        }
        /// <summary>
        /// Expected to be unsigned integer.
        ///</summary>
        [JsonPropertyName("keepAliveDelay")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? KeepAliveDelay
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
        /// Gets or sets the dnsQueryType
        /// </summary>
        [JsonPropertyName("dnsQueryType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DirectSocketDnsQueryType? DnsQueryType
        {
            get;
            set;
        }
    }
}
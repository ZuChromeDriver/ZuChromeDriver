namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class NetworkConditions
    {
        /// <summary>
        /// Only matching requests will be affected by these conditions. Patterns use the URLPattern constructor string
        /// syntax (https://urlpattern.spec.whatwg.org/) and must be absolute. If the pattern is empty, all requests are
        /// matched (including p2p connections).
        ///</summary>
        [JsonPropertyName("urlPattern")]
        public string UrlPattern
        {
            get;
            set;
        }
        /// <summary>
        /// Minimum latency from request sent to response headers received (ms).
        ///</summary>
        [JsonPropertyName("latency")]
        public double Latency
        {
            get;
            set;
        }
        /// <summary>
        /// Maximal aggregated download throughput (bytes/sec). -1 disables download throttling.
        ///</summary>
        [JsonPropertyName("downloadThroughput")]
        public double DownloadThroughput
        {
            get;
            set;
        }
        /// <summary>
        /// Maximal aggregated upload throughput (bytes/sec).  -1 disables upload throttling.
        ///</summary>
        [JsonPropertyName("uploadThroughput")]
        public double UploadThroughput
        {
            get;
            set;
        }
        /// <summary>
        /// Connection type if known.
        ///</summary>
        [JsonPropertyName("connectionType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ConnectionType? ConnectionType
        {
            get;
            set;
        }
        /// <summary>
        /// WebRTC packet loss (percent, 0-100). 0 disables packet loss emulation, 100 drops all the packets.
        ///</summary>
        [JsonPropertyName("packetLoss")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? PacketLoss
        {
            get;
            set;
        }
        /// <summary>
        /// WebRTC packet queue length (packet). 0 removes any queue length limitations.
        ///</summary>
        [JsonPropertyName("packetQueueLength")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? PacketQueueLength
        {
            get;
            set;
        }
        /// <summary>
        /// WebRTC packetReordering feature.
        ///</summary>
        [JsonPropertyName("packetReordering")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? PacketReordering
        {
            get;
            set;
        }
        /// <summary>
        /// True to emulate internet disconnection.
        ///</summary>
        [JsonPropertyName("offline")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Offline
        {
            get;
            set;
        }
    }
}
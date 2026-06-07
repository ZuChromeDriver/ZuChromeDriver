namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Activates emulation of network conditions. This command is deprecated in favor of the emulateNetworkConditionsByRule
    /// and overrideNetworkState commands, which can be used together to the same effect.
    /// </summary>
    public sealed class EmulateNetworkConditionsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Network.emulateNetworkConditions";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// True to emulate internet disconnection.
        /// </summary>
        [JsonPropertyName("offline")]
        public bool Offline
        {
            get;
            set;
        }
        /// <summary>
        /// Minimum latency from request sent to response headers received (ms).
        /// </summary>
        [JsonPropertyName("latency")]
        public double Latency
        {
            get;
            set;
        }
        /// <summary>
        /// Maximal aggregated download throughput (bytes/sec). -1 disables download throttling.
        /// </summary>
        [JsonPropertyName("downloadThroughput")]
        public double DownloadThroughput
        {
            get;
            set;
        }
        /// <summary>
        /// Maximal aggregated upload throughput (bytes/sec).  -1 disables upload throttling.
        /// </summary>
        [JsonPropertyName("uploadThroughput")]
        public double UploadThroughput
        {
            get;
            set;
        }
        /// <summary>
        /// Connection type if known.
        /// </summary>
        [JsonPropertyName("connectionType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ConnectionType? ConnectionType
        {
            get;
            set;
        }
        /// <summary>
        /// WebRTC packet loss (percent, 0-100). 0 disables packet loss emulation, 100 drops all the packets.
        /// </summary>
        [JsonPropertyName("packetLoss")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? PacketLoss
        {
            get;
            set;
        }
        /// <summary>
        /// WebRTC packet queue length (packet). 0 removes any queue length limitations.
        /// </summary>
        [JsonPropertyName("packetQueueLength")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? PacketQueueLength
        {
            get;
            set;
        }
        /// <summary>
        /// WebRTC packetReordering feature.
        /// </summary>
        [JsonPropertyName("packetReordering")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? PacketReordering
        {
            get;
            set;
        }
    }

    public sealed class EmulateNetworkConditionsCommandResponse : ICommandResponse<EmulateNetworkConditionsCommand>
    {
    }
}
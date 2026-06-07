namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Override the state of navigator.onLine and navigator.connection.
    /// </summary>
    public sealed class OverrideNetworkStateCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Network.overrideNetworkState";
        
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
    }

    public sealed class OverrideNetworkStateCommandResponse : ICommandResponse<OverrideNetworkStateCommand>
    {
    }
}
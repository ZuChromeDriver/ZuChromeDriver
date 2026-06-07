namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Enables network tracking, network events will now be delivered to the client.
    /// </summary>
    public sealed class EnableCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Network.enable";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Buffer size in bytes to use when preserving network payloads (XHRs, etc).
        /// This is the maximum number of bytes that will be collected by this
        /// DevTools session.
        /// </summary>
        [JsonPropertyName("maxTotalBufferSize")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? MaxTotalBufferSize
        {
            get;
            set;
        }
        /// <summary>
        /// Per-resource buffer size in bytes to use when preserving network payloads (XHRs, etc).
        /// </summary>
        [JsonPropertyName("maxResourceBufferSize")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? MaxResourceBufferSize
        {
            get;
            set;
        }
        /// <summary>
        /// Longest post body size (in bytes) that would be included in requestWillBeSent notification
        /// </summary>
        [JsonPropertyName("maxPostDataSize")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? MaxPostDataSize
        {
            get;
            set;
        }
        /// <summary>
        /// Whether DirectSocket chunk send/receive events should be reported.
        /// </summary>
        [JsonPropertyName("reportDirectSocketTraffic")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? ReportDirectSocketTraffic
        {
            get;
            set;
        }
        /// <summary>
        /// Enable storing response bodies outside of renderer, so that these survive
        /// a cross-process navigation. Requires maxTotalBufferSize to be set.
        /// Currently defaults to false. This field is being deprecated in favor of the dedicated
        /// configureDurableMessages command, due to the possibility of deadlocks when awaiting
        /// Network.enable before issuing Runtime.runIfWaitingForDebugger.
        /// </summary>
        [JsonPropertyName("enableDurableMessages")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? EnableDurableMessages
        {
            get;
            set;
        }
    }

    public sealed class EnableCommandResponse : ICommandResponse<EnableCommand>
    {
    }
}
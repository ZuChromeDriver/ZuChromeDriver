namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Configures storing response bodies outside of renderer, so that these survive
    /// a cross-process navigation.
    /// If maxTotalBufferSize is not set, durable messages are disabled.
    /// </summary>
    public sealed class ConfigureDurableMessagesCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Network.configureDurableMessages";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Buffer size in bytes to use when preserving network payloads (XHRs, etc).
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
    }

    public sealed class ConfigureDurableMessagesCommandResponse : ICommandResponse<ConfigureDurableMessagesCommand>
    {
    }
}
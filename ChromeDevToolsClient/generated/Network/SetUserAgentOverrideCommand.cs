namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Allows overriding user agent with the given string.
    /// </summary>
    public sealed class SetUserAgentOverrideCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Network.setUserAgentOverride";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// User agent to use.
        /// </summary>
        [JsonPropertyName("userAgent")]
        public string UserAgent
        {
            get;
            set;
        }
        /// <summary>
        /// Browser language to emulate.
        /// </summary>
        [JsonPropertyName("acceptLanguage")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string AcceptLanguage
        {
            get;
            set;
        }
        /// <summary>
        /// The platform navigator.platform should return.
        /// </summary>
        [JsonPropertyName("platform")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Platform
        {
            get;
            set;
        }
        /// <summary>
        /// To be sent in Sec-CH-UA-* headers and returned in navigator.userAgentData
        /// </summary>
        [JsonPropertyName("userAgentMetadata")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Emulation.UserAgentMetadata UserAgentMetadata
        {
            get;
            set;
        }
    }

    public sealed class SetUserAgentOverrideCommandResponse : ICommandResponse<SetUserAgentOverrideCommand>
    {
    }
}
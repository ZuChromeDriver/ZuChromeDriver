namespace Zu.ChromeDevTools.Browser
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns version information.
    /// </summary>
    public sealed class GetVersionCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Browser.getVersion";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class GetVersionCommandResponse : ICommandResponse<GetVersionCommand>
    {
        /// <summary>
        /// Protocol version.
        ///</summary>
        [JsonPropertyName("protocolVersion")]
        public string ProtocolVersion
        {
            get;
            set;
        }
        /// <summary>
        /// Product name.
        ///</summary>
        [JsonPropertyName("product")]
        public string Product
        {
            get;
            set;
        }
        /// <summary>
        /// Product revision.
        ///</summary>
        [JsonPropertyName("revision")]
        public string Revision
        {
            get;
            set;
        }
        /// <summary>
        /// User-Agent.
        ///</summary>
        [JsonPropertyName("userAgent")]
        public string UserAgent
        {
            get;
            set;
        }
        /// <summary>
        /// V8 version.
        ///</summary>
        [JsonPropertyName("jsVersion")]
        public string JsVersion
        {
            get;
            set;
        }
    }
}
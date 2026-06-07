namespace Zu.ChromeDevTools.Target
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Creates a new empty BrowserContext. Similar to an incognito profile but you can have more than
    /// one.
    /// </summary>
    public sealed class CreateBrowserContextCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Target.createBrowserContext";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// If specified, disposes this context when debugging session disconnects.
        /// </summary>
        [JsonPropertyName("disposeOnDetach")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? DisposeOnDetach
        {
            get;
            set;
        }
        /// <summary>
        /// Proxy server, similar to the one passed to --proxy-server
        /// </summary>
        [JsonPropertyName("proxyServer")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ProxyServer
        {
            get;
            set;
        }
        /// <summary>
        /// Proxy bypass list, similar to the one passed to --proxy-bypass-list
        /// </summary>
        [JsonPropertyName("proxyBypassList")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ProxyBypassList
        {
            get;
            set;
        }
        /// <summary>
        /// An optional list of origins to grant unlimited cross-origin access to.
        /// Parts of the URL other than those constituting origin are ignored.
        /// </summary>
        [JsonPropertyName("originsWithUniversalNetworkAccess")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string[] OriginsWithUniversalNetworkAccess
        {
            get;
            set;
        }
    }

    public sealed class CreateBrowserContextCommandResponse : ICommandResponse<CreateBrowserContextCommand>
    {
        /// <summary>
        /// The id of the context created.
        ///</summary>
        [JsonPropertyName("browserContextId")]
        public string BrowserContextId
        {
            get;
            set;
        }
    }
}
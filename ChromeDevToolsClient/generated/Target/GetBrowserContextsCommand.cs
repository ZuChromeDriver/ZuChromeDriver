namespace Zu.ChromeDevTools.Target
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns all browser contexts created with `Target.createBrowserContext` method.
    /// </summary>
    public sealed class GetBrowserContextsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Target.getBrowserContexts";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class GetBrowserContextsCommandResponse : ICommandResponse<GetBrowserContextsCommand>
    {
        /// <summary>
        /// An array of browser context ids.
        ///</summary>
        [JsonPropertyName("browserContextIds")]
        public string[] BrowserContextIds
        {
            get;
            set;
        }
        /// <summary>
        /// The id of the default browser context if available.
        ///</summary>
        [JsonPropertyName("defaultBrowserContextId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string DefaultBrowserContextId
        {
            get;
            set;
        }
    }
}
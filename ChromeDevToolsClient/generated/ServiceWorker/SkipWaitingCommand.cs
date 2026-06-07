namespace Zu.ChromeDevTools.ServiceWorker
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class SkipWaitingCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "ServiceWorker.skipWaiting";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the scopeURL
        /// </summary>
        [JsonPropertyName("scopeURL")]
        public string ScopeURL
        {
            get;
            set;
        }
    }

    public sealed class SkipWaitingCommandResponse : ICommandResponse<SkipWaitingCommand>
    {
    }
}
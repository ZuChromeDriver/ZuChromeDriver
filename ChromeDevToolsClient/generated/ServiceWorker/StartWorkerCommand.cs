namespace Zu.ChromeDevTools.ServiceWorker
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class StartWorkerCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "ServiceWorker.startWorker";
        
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

    public sealed class StartWorkerCommandResponse : ICommandResponse<StartWorkerCommand>
    {
    }
}
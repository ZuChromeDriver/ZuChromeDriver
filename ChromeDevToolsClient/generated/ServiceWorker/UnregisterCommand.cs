namespace Zu.ChromeDevTools.ServiceWorker
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class UnregisterCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "ServiceWorker.unregister";
        
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

    public sealed class UnregisterCommandResponse : ICommandResponse<UnregisterCommand>
    {
    }
}
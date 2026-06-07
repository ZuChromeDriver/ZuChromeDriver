namespace Zu.ChromeDevTools.ServiceWorker
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class UpdateRegistrationCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "ServiceWorker.updateRegistration";
        
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

    public sealed class UpdateRegistrationCommandResponse : ICommandResponse<UpdateRegistrationCommand>
    {
    }
}
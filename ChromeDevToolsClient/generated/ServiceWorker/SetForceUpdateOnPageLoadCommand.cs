namespace Zu.ChromeDevTools.ServiceWorker
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class SetForceUpdateOnPageLoadCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "ServiceWorker.setForceUpdateOnPageLoad";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the forceUpdateOnPageLoad
        /// </summary>
        [JsonPropertyName("forceUpdateOnPageLoad")]
        public bool ForceUpdateOnPageLoad
        {
            get;
            set;
        }
    }

    public sealed class SetForceUpdateOnPageLoadCommandResponse : ICommandResponse<SetForceUpdateOnPageLoadCommand>
    {
    }
}
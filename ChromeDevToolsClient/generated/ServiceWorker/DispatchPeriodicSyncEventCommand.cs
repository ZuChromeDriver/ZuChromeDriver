namespace Zu.ChromeDevTools.ServiceWorker
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class DispatchPeriodicSyncEventCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "ServiceWorker.dispatchPeriodicSyncEvent";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the origin
        /// </summary>
        [JsonPropertyName("origin")]
        public string Origin
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the registrationId
        /// </summary>
        [JsonPropertyName("registrationId")]
        public string RegistrationId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the tag
        /// </summary>
        [JsonPropertyName("tag")]
        public string Tag
        {
            get;
            set;
        }
    }

    public sealed class DispatchPeriodicSyncEventCommandResponse : ICommandResponse<DispatchPeriodicSyncEventCommand>
    {
    }
}
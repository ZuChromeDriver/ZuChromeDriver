namespace Zu.ChromeDevTools.ServiceWorker
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class DispatchSyncEventCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "ServiceWorker.dispatchSyncEvent";
        
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
        /// <summary>
        /// Gets or sets the lastChance
        /// </summary>
        [JsonPropertyName("lastChance")]
        public bool LastChance
        {
            get;
            set;
        }
    }

    public sealed class DispatchSyncEventCommandResponse : ICommandResponse<DispatchSyncEventCommand>
    {
    }
}
namespace Zu.ChromeDevTools.ServiceWorker
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class DeliverPushMessageCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "ServiceWorker.deliverPushMessage";
        
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
        /// Gets or sets the data
        /// </summary>
        [JsonPropertyName("data")]
        public string Data
        {
            get;
            set;
        }
    }

    public sealed class DeliverPushMessageCommandResponse : ICommandResponse<DeliverPushMessageCommand>
    {
    }
}
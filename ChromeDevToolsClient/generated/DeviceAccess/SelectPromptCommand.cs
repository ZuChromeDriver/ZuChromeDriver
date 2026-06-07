namespace Zu.ChromeDevTools.DeviceAccess
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Select a device in response to a DeviceAccess.deviceRequestPrompted event.
    /// </summary>
    public sealed class SelectPromptCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DeviceAccess.selectPrompt";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the deviceId
        /// </summary>
        [JsonPropertyName("deviceId")]
        public string DeviceId
        {
            get;
            set;
        }
    }

    public sealed class SelectPromptCommandResponse : ICommandResponse<SelectPromptCommand>
    {
    }
}
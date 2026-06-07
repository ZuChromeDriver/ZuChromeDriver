namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Deletes a device bound session.
    /// </summary>
    public sealed class DeleteDeviceBoundSessionCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Network.deleteDeviceBoundSession";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the key
        /// </summary>
        [JsonPropertyName("key")]
        public DeviceBoundSessionKey Key
        {
            get;
            set;
        }
    }

    public sealed class DeleteDeviceBoundSessionCommandResponse : ICommandResponse<DeleteDeviceBoundSessionCommand>
    {
    }
}
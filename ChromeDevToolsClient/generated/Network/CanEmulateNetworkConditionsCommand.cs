namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Tells whether emulation of network conditions is supported.
    /// </summary>
    public sealed class CanEmulateNetworkConditionsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Network.canEmulateNetworkConditions";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class CanEmulateNetworkConditionsCommandResponse : ICommandResponse<CanEmulateNetworkConditionsCommand>
    {
        /// <summary>
        /// True if emulation of network conditions is supported.
        ///</summary>
        [JsonPropertyName("result")]
        public bool Result
        {
            get;
            set;
        }
    }
}
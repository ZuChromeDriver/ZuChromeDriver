namespace Zu.ChromeDevTools.BluetoothEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Enable the BluetoothEmulation domain.
    /// </summary>
    public sealed class EnableCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "BluetoothEmulation.enable";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// State of the simulated central.
        /// </summary>
        [JsonPropertyName("state")]
        public CentralState State
        {
            get;
            set;
        }
        /// <summary>
        /// If the simulated central supports low-energy.
        /// </summary>
        [JsonPropertyName("leSupported")]
        public bool LeSupported
        {
            get;
            set;
        }
    }

    public sealed class EnableCommandResponse : ICommandResponse<EnableCommand>
    {
    }
}
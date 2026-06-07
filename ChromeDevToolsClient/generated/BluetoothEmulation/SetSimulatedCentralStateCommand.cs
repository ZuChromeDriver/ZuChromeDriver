namespace Zu.ChromeDevTools.BluetoothEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Set the state of the simulated central.
    /// </summary>
    public sealed class SetSimulatedCentralStateCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "BluetoothEmulation.setSimulatedCentralState";
        
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
    }

    public sealed class SetSimulatedCentralStateCommandResponse : ICommandResponse<SetSimulatedCentralStateCommand>
    {
    }
}
namespace Zu.ChromeDevTools.BluetoothEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Simulates a peripheral with |address|, |name| and |knownServiceUuids|
    /// that has already been connected to the system.
    /// </summary>
    public sealed class SimulatePreconnectedPeripheralCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "BluetoothEmulation.simulatePreconnectedPeripheral";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the address
        /// </summary>
        [JsonPropertyName("address")]
        public string Address
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the manufacturerData
        /// </summary>
        [JsonPropertyName("manufacturerData")]
        public ManufacturerData[] ManufacturerData
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the knownServiceUuids
        /// </summary>
        [JsonPropertyName("knownServiceUuids")]
        public string[] KnownServiceUuids
        {
            get;
            set;
        }
    }

    public sealed class SimulatePreconnectedPeripheralCommandResponse : ICommandResponse<SimulatePreconnectedPeripheralCommand>
    {
    }
}
namespace Zu.ChromeDevTools.BluetoothEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Simulates the response from the descriptor with |descriptorId| for a
    /// descriptor operation of |type|. The |code| value follows the Error
    /// Codes from Bluetooth Core Specification Vol 3 Part F 3.4.1.1 Error Response.
    /// The |data| is expected to exist when simulating a successful read operation
    /// response.
    /// </summary>
    public sealed class SimulateDescriptorOperationResponseCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "BluetoothEmulation.simulateDescriptorOperationResponse";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the descriptorId
        /// </summary>
        [JsonPropertyName("descriptorId")]
        public string DescriptorId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the type
        /// </summary>
        [JsonPropertyName("type")]
        public DescriptorOperationType Type
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the code
        /// </summary>
        [JsonPropertyName("code")]
        public long Code
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the data
        /// </summary>
        [JsonPropertyName("data")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Data
        {
            get;
            set;
        }
    }

    public sealed class SimulateDescriptorOperationResponseCommandResponse : ICommandResponse<SimulateDescriptorOperationResponseCommand>
    {
    }
}
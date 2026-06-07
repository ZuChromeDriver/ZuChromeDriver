namespace Zu.ChromeDevTools.BluetoothEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Adds a descriptor with |descriptorUuid| to the characteristic respresented
    /// by |characteristicId|.
    /// </summary>
    public sealed class AddDescriptorCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "BluetoothEmulation.addDescriptor";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the characteristicId
        /// </summary>
        [JsonPropertyName("characteristicId")]
        public string CharacteristicId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the descriptorUuid
        /// </summary>
        [JsonPropertyName("descriptorUuid")]
        public string DescriptorUuid
        {
            get;
            set;
        }
    }

    public sealed class AddDescriptorCommandResponse : ICommandResponse<AddDescriptorCommand>
    {
        /// <summary>
        /// An identifier that uniquely represents this descriptor.
        ///</summary>
        [JsonPropertyName("descriptorId")]
        public string DescriptorId
        {
            get;
            set;
        }
    }
}
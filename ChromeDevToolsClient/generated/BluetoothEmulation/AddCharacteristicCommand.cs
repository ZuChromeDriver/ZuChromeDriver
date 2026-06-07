namespace Zu.ChromeDevTools.BluetoothEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Adds a characteristic with |characteristicUuid| and |properties| to the
    /// service represented by |serviceId|.
    /// </summary>
    public sealed class AddCharacteristicCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "BluetoothEmulation.addCharacteristic";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the serviceId
        /// </summary>
        [JsonPropertyName("serviceId")]
        public string ServiceId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the characteristicUuid
        /// </summary>
        [JsonPropertyName("characteristicUuid")]
        public string CharacteristicUuid
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the properties
        /// </summary>
        [JsonPropertyName("properties")]
        public CharacteristicProperties Properties
        {
            get;
            set;
        }
    }

    public sealed class AddCharacteristicCommandResponse : ICommandResponse<AddCharacteristicCommand>
    {
        /// <summary>
        /// An identifier that uniquely represents this characteristic.
        ///</summary>
        [JsonPropertyName("characteristicId")]
        public string CharacteristicId
        {
            get;
            set;
        }
    }
}
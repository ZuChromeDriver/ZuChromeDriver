namespace Zu.ChromeDevTools.BluetoothEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Stores the byte data of the advertisement packet sent by a Bluetooth device.
    /// </summary>
    public sealed class ScanRecord
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the uuids
        /// </summary>
        [JsonPropertyName("uuids")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string[] Uuids
        {
            get;
            set;
        }
        /// <summary>
        /// Stores the external appearance description of the device.
        ///</summary>
        [JsonPropertyName("appearance")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Appearance
        {
            get;
            set;
        }
        /// <summary>
        /// Stores the transmission power of a broadcasting device.
        ///</summary>
        [JsonPropertyName("txPower")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? TxPower
        {
            get;
            set;
        }
        /// <summary>
        /// Key is the company identifier and the value is an array of bytes of
        /// manufacturer specific data.
        ///</summary>
        [JsonPropertyName("manufacturerData")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ManufacturerData[] ManufacturerData
        {
            get;
            set;
        }
    }
}
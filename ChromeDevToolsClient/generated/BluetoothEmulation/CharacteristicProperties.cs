namespace Zu.ChromeDevTools.BluetoothEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Describes the properties of a characteristic. This follows Bluetooth Core
    /// Specification BT 4.2 Vol 3 Part G 3.3.1. Characteristic Properties.
    /// </summary>
    public sealed class CharacteristicProperties
    {
        /// <summary>
        /// Gets or sets the broadcast
        /// </summary>
        [JsonPropertyName("broadcast")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Broadcast
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the read
        /// </summary>
        [JsonPropertyName("read")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Read
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the writeWithoutResponse
        /// </summary>
        [JsonPropertyName("writeWithoutResponse")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? WriteWithoutResponse
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the write
        /// </summary>
        [JsonPropertyName("write")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Write
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the notify
        /// </summary>
        [JsonPropertyName("notify")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Notify
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the indicate
        /// </summary>
        [JsonPropertyName("indicate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Indicate
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the authenticatedSignedWrites
        /// </summary>
        [JsonPropertyName("authenticatedSignedWrites")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? AuthenticatedSignedWrites
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the extendedProperties
        /// </summary>
        [JsonPropertyName("extendedProperties")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? ExtendedProperties
        {
            get;
            set;
        }
    }
}
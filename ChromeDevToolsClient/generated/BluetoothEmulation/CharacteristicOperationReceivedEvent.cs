namespace Zu.ChromeDevTools.BluetoothEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Event for when a characteristic operation of |type| to the characteristic
    /// respresented by |characteristicId| happened. |data| and |writeType| is
    /// expected to exist when |type| is write.
    /// </summary>
    public sealed class CharacteristicOperationReceivedEvent : IEvent
    {
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
        /// Gets or sets the type
        /// </summary>
        [JsonPropertyName("type")]
        public CharacteristicOperationType Type
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
        /// <summary>
        /// Gets or sets the writeType
        /// </summary>
        [JsonPropertyName("writeType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CharacteristicWriteType? WriteType
        {
            get;
            set;
        }
    }
}
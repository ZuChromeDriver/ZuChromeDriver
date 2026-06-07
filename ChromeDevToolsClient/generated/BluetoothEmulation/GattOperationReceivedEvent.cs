namespace Zu.ChromeDevTools.BluetoothEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Event for when a GATT operation of |type| to the peripheral with |address|
    /// happened.
    /// </summary>
    public sealed class GattOperationReceivedEvent : IEvent
    {
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
        /// Gets or sets the type
        /// </summary>
        [JsonPropertyName("type")]
        public GATTOperationType Type
        {
            get;
            set;
        }
    }
}
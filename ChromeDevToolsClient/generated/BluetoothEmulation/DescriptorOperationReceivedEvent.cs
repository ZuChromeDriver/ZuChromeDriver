namespace Zu.ChromeDevTools.BluetoothEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Event for when a descriptor operation of |type| to the descriptor
    /// respresented by |descriptorId| happened. |data| is expected to exist when
    /// |type| is write.
    /// </summary>
    public sealed class DescriptorOperationReceivedEvent : IEvent
    {
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
}
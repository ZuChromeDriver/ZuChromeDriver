namespace Zu.ChromeDevTools.Runtime
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents deep serialized value.
    /// </summary>
    public sealed class DeepSerializedValue
    {
        /// <summary>
        /// Gets or sets the type
        /// </summary>
        [JsonPropertyName("type")]
        public string Type
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the value
        /// </summary>
        [JsonPropertyName("value")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public object Value
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the objectId
        /// </summary>
        [JsonPropertyName("objectId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ObjectId
        {
            get;
            set;
        }
        /// <summary>
        /// Set if value reference met more then once during serialization. In such
        /// case, value is provided only to one of the serialized values. Unique
        /// per value in the scope of one CDP call.
        ///</summary>
        [JsonPropertyName("weakLocalObjectReference")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? WeakLocalObjectReference
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.Runtime
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents function call argument. Either remote object id `objectId`, primitive `value`,
    /// unserializable primitive value or neither of (for undefined) them should be specified.
    /// </summary>
    public sealed class CallArgument
    {
        /// <summary>
        /// Primitive value or serializable javascript object.
        ///</summary>
        [JsonPropertyName("value")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public object Value
        {
            get;
            set;
        }
        /// <summary>
        /// Primitive value which can not be JSON-stringified.
        ///</summary>
        [JsonPropertyName("unserializableValue")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string UnserializableValue
        {
            get;
            set;
        }
        /// <summary>
        /// Remote object handle.
        ///</summary>
        [JsonPropertyName("objectId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ObjectId
        {
            get;
            set;
        }
    }
}
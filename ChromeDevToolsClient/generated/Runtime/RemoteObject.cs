namespace Zu.ChromeDevTools.Runtime
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Mirror object referencing original JavaScript object.
    /// </summary>
    public sealed class RemoteObject
    {
        /// <summary>
        /// Object type.
        ///</summary>
        [JsonPropertyName("type")]
        public string Type
        {
            get;
            set;
        }
        /// <summary>
        /// Object subtype hint. Specified for `object` type values only.
        /// NOTE: If you change anything here, make sure to also update
        /// `subtype` in `ObjectPreview` and `PropertyPreview` below.
        ///</summary>
        [JsonPropertyName("subtype")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Subtype
        {
            get;
            set;
        }
        /// <summary>
        /// Object class (constructor) name. Specified for `object` type values only.
        ///</summary>
        [JsonPropertyName("className")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ClassName
        {
            get;
            set;
        }
        /// <summary>
        /// Remote object value in case of primitive values or JSON values (if it was requested).
        ///</summary>
        [JsonPropertyName("value")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public object Value
        {
            get;
            set;
        }
        /// <summary>
        /// Primitive value which can not be JSON-stringified does not have `value`, but gets this
        /// property.
        ///</summary>
        [JsonPropertyName("unserializableValue")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string UnserializableValue
        {
            get;
            set;
        }
        /// <summary>
        /// String representation of the object.
        ///</summary>
        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Description
        {
            get;
            set;
        }
        /// <summary>
        /// Deep serialized value.
        ///</summary>
        [JsonPropertyName("deepSerializedValue")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DeepSerializedValue DeepSerializedValue
        {
            get;
            set;
        }
        /// <summary>
        /// Unique object identifier (for non-primitive values).
        ///</summary>
        [JsonPropertyName("objectId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ObjectId
        {
            get;
            set;
        }
        /// <summary>
        /// Preview containing abbreviated property values. Specified for `object` type values only.
        ///</summary>
        [JsonPropertyName("preview")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ObjectPreview Preview
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the customPreview
        /// </summary>
        [JsonPropertyName("customPreview")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CustomPreview CustomPreview
        {
            get;
            set;
        }
    }
}
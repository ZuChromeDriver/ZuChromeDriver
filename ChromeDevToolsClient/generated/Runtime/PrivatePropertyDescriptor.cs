namespace Zu.ChromeDevTools.Runtime
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Object private field descriptor.
    /// </summary>
    public sealed class PrivatePropertyDescriptor
    {
        /// <summary>
        /// Private property name.
        ///</summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// The value associated with the private property.
        ///</summary>
        [JsonPropertyName("value")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public RemoteObject Value
        {
            get;
            set;
        }
        /// <summary>
        /// A function which serves as a getter for the private property,
        /// or `undefined` if there is no getter (accessor descriptors only).
        ///</summary>
        [JsonPropertyName("get")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public RemoteObject Get
        {
            get;
            set;
        }
        /// <summary>
        /// A function which serves as a setter for the private property,
        /// or `undefined` if there is no setter (accessor descriptors only).
        ///</summary>
        [JsonPropertyName("set")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public RemoteObject Set
        {
            get;
            set;
        }
    }
}
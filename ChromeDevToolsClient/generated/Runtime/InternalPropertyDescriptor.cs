namespace Zu.ChromeDevTools.Runtime
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Object internal property descriptor. This property isn't normally visible in JavaScript code.
    /// </summary>
    public sealed class InternalPropertyDescriptor
    {
        /// <summary>
        /// Conventional property name.
        ///</summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// The value associated with the property.
        ///</summary>
        [JsonPropertyName("value")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public RemoteObject Value
        {
            get;
            set;
        }
    }
}
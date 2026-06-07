namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when `Element`'s attribute is modified.
    /// </summary>
    public sealed class AttributeModifiedEvent : IEvent
    {
        /// <summary>
        /// Id of the node that has changed.
        /// </summary>
        [JsonPropertyName("nodeId")]
        public long NodeId
        {
            get;
            set;
        }
        /// <summary>
        /// Attribute name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Attribute value.
        /// </summary>
        [JsonPropertyName("value")]
        public string Value
        {
            get;
            set;
        }
    }
}
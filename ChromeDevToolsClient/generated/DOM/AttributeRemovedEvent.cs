namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when `Element`'s attribute is removed.
    /// </summary>
    public sealed class AttributeRemovedEvent : IEvent
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
        /// A ttribute name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
    }
}
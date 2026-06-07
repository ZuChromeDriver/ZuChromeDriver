namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when `Element`'s inline style is modified via a CSS property modification.
    /// </summary>
    public sealed class InlineStyleInvalidatedEvent : IEvent
    {
        /// <summary>
        /// Ids of the nodes for which the inline styles have been invalidated.
        /// </summary>
        [JsonPropertyName("nodeIds")]
        public long[] NodeIds
        {
            get;
            set;
        }
    }
}
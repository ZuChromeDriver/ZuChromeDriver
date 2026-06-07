namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Called when a pseudo element is removed from an element.
    /// </summary>
    public sealed class PseudoElementRemovedEvent : IEvent
    {
        /// <summary>
        /// Pseudo element's parent element id.
        /// </summary>
        [JsonPropertyName("parentId")]
        public long ParentId
        {
            get;
            set;
        }
        /// <summary>
        /// The removed pseudo element id.
        /// </summary>
        [JsonPropertyName("pseudoElementId")]
        public long PseudoElementId
        {
            get;
            set;
        }
    }
}
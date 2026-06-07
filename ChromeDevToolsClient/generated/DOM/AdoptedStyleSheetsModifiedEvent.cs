namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when `Element`'s adoptedStyleSheets are modified.
    /// </summary>
    public sealed class AdoptedStyleSheetsModifiedEvent : IEvent
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
        /// New adoptedStyleSheets array.
        /// </summary>
        [JsonPropertyName("adoptedStyleSheets")]
        public string[] AdoptedStyleSheets
        {
            get;
            set;
        }
    }
}
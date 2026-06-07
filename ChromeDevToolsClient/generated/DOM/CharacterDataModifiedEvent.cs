namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Mirrors `DOMCharacterDataModified` event.
    /// </summary>
    public sealed class CharacterDataModifiedEvent : IEvent
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
        /// New text value.
        /// </summary>
        [JsonPropertyName("characterData")]
        public string CharacterData
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when a node's ad related state changes.
    /// </summary>
    public sealed class AdRelatedStateUpdatedEvent : IEvent
    {
        /// <summary>
        /// The id of the node.
        /// </summary>
        [JsonPropertyName("nodeId")]
        public long NodeId
        {
            get;
            set;
        }
        /// <summary>
        /// The provenance of the ad related node, if it is ad related.
        /// </summary>
        [JsonPropertyName("adProvenance")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Network.AdProvenance AdProvenance
        {
            get;
            set;
        }
    }
}
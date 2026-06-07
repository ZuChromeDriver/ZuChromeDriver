namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when a node's starting styles changes.
    /// </summary>
    public sealed class AffectedByStartingStylesFlagUpdatedEvent : IEvent
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
        /// If the node has starting styles.
        /// </summary>
        [JsonPropertyName("affectedByStartingStyles")]
        public bool AffectedByStartingStyles
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when user asks to restore the Inspected Element floating window.
    /// </summary>
    public sealed class InspectedElementWindowRestoredEvent : IEvent
    {
        /// <summary>
        /// Id of the node to restore the floating window for.
        /// </summary>
        [JsonPropertyName("backendNodeId")]
        public long BackendNodeId
        {
            get;
            set;
        }
    }
}
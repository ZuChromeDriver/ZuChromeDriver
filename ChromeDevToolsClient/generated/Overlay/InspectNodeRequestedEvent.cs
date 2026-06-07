namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when the node should be inspected. This happens after call to `setInspectMode` or when
    /// user manually inspects an element.
    /// </summary>
    public sealed class InspectNodeRequestedEvent : IEvent
    {
        /// <summary>
        /// Id of the node to inspect.
        /// </summary>
        [JsonPropertyName("backendNodeId")]
        public long BackendNodeId
        {
            get;
            set;
        }
    }
}
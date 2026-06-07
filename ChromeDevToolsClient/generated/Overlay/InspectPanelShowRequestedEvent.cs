namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when user asks to show the Inspect panel.
    /// </summary>
    public sealed class InspectPanelShowRequestedEvent : IEvent
    {
        /// <summary>
        /// Id of the node to show in the panel.
        /// </summary>
        [JsonPropertyName("backendNodeId")]
        public long BackendNodeId
        {
            get;
            set;
        }
    }
}
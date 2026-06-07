namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Called when shadow root is pushed into the element.
    /// </summary>
    public sealed class ShadowRootPushedEvent : IEvent
    {
        /// <summary>
        /// Host element id.
        /// </summary>
        [JsonPropertyName("hostId")]
        public long HostId
        {
            get;
            set;
        }
        /// <summary>
        /// Shadow root.
        /// </summary>
        [JsonPropertyName("root")]
        public Node Root
        {
            get;
            set;
        }
    }
}
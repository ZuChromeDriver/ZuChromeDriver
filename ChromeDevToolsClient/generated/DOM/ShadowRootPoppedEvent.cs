namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Called when shadow root is popped from the element.
    /// </summary>
    public sealed class ShadowRootPoppedEvent : IEvent
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
        /// Shadow root id.
        /// </summary>
        [JsonPropertyName("rootId")]
        public long RootId
        {
            get;
            set;
        }
    }
}
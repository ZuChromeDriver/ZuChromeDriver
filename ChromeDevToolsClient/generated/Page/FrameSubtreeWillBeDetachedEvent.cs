namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired before frame subtree is detached. Emitted before any frame of the
    /// subtree is actually detached.
    /// </summary>
    public sealed class FrameSubtreeWillBeDetachedEvent : IEvent
    {
        /// <summary>
        /// Id of the frame that is the root of the subtree that will be detached.
        /// </summary>
        [JsonPropertyName("frameId")]
        public string FrameId
        {
            get;
            set;
        }
    }
}
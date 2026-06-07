namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when frame no longer has a scheduled navigation.
    /// </summary>
    public sealed class FrameClearedScheduledNavigationEvent : IEvent
    {
        /// <summary>
        /// Id of the frame that has cleared its scheduled navigation.
        /// </summary>
        [JsonPropertyName("frameId")]
        public string FrameId
        {
            get;
            set;
        }
    }
}
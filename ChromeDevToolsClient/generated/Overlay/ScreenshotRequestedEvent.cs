namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when user asks to capture screenshot of some area on the page.
    /// </summary>
    public sealed class ScreenshotRequestedEvent : IEvent
    {
        /// <summary>
        /// Viewport to capture, in device independent pixels (dip).
        /// </summary>
        [JsonPropertyName("viewport")]
        public Page.Viewport Viewport
        {
            get;
            set;
        }
    }
}
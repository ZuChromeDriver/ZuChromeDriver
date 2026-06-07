namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when the page with currently enabled screencast was shown or hidden `.
    /// </summary>
    public sealed class ScreencastVisibilityChangedEvent : IEvent
    {
        /// <summary>
        /// True if the page is visible.
        /// </summary>
        [JsonPropertyName("visible")]
        public bool Visible
        {
            get;
            set;
        }
    }
}
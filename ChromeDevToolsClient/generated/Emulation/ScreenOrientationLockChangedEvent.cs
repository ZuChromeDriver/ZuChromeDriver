namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when a page calls screen.orientation.lock() or screen.orientation.unlock()
    /// while device emulation is enabled. This allows the DevTools frontend to update the
    /// emulated device orientation accordingly.
    /// </summary>
    public sealed class ScreenOrientationLockChangedEvent : IEvent
    {
        /// <summary>
        /// Whether the screen orientation is currently locked.
        /// </summary>
        [JsonPropertyName("locked")]
        public bool Locked
        {
            get;
            set;
        }
        /// <summary>
        /// The orientation lock type requested by the page. Only set when locked is true.
        /// </summary>
        [JsonPropertyName("orientation")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ScreenOrientation Orientation
        {
            get;
            set;
        }
    }
}
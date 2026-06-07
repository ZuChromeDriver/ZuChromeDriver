namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Configuration for Window Controls Overlay
    /// </summary>
    public sealed class WindowControlsOverlayConfig
    {
        /// <summary>
        /// Whether the title bar CSS should be shown when emulating the Window Controls Overlay.
        ///</summary>
        [JsonPropertyName("showCSS")]
        public bool ShowCSS
        {
            get;
            set;
        }
        /// <summary>
        /// Selected platforms to show the overlay.
        ///</summary>
        [JsonPropertyName("selectedPlatform")]
        public string SelectedPlatform
        {
            get;
            set;
        }
        /// <summary>
        /// The theme color defined in app manifest.
        ///</summary>
        [JsonPropertyName("themeColor")]
        public string ThemeColor
        {
            get;
            set;
        }
    }
}
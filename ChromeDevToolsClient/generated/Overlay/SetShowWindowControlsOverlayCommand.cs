namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Show Window Controls Overlay for PWA
    /// </summary>
    public sealed class SetShowWindowControlsOverlayCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Overlay.setShowWindowControlsOverlay";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Window Controls Overlay data, null means hide Window Controls Overlay
        /// </summary>
        [JsonPropertyName("windowControlsOverlayConfig")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public WindowControlsOverlayConfig WindowControlsOverlayConfig
        {
            get;
            set;
        }
    }

    public sealed class SetShowWindowControlsOverlayCommandResponse : ICommandResponse<SetShowWindowControlsOverlayCommand>
    {
    }
}
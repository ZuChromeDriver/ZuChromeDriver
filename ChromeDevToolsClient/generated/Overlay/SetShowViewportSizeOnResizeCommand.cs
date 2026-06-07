namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Paints viewport size upon main frame resize.
    /// </summary>
    public sealed class SetShowViewportSizeOnResizeCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Overlay.setShowViewportSizeOnResize";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Whether to paint size or not.
        /// </summary>
        [JsonPropertyName("show")]
        public bool Show
        {
            get;
            set;
        }
    }

    public sealed class SetShowViewportSizeOnResizeCommandResponse : ICommandResponse<SetShowViewportSizeOnResizeCommand>
    {
    }
}
namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Requests that backend shows the FPS counter
    /// </summary>
    public sealed class SetShowFPSCounterCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Overlay.setShowFPSCounter";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// True for showing the FPS counter
        /// </summary>
        [JsonPropertyName("show")]
        public bool Show
        {
            get;
            set;
        }
    }

    public sealed class SetShowFPSCounterCommandResponse : ICommandResponse<SetShowFPSCounterCommand>
    {
    }
}
namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Deprecated, no longer has any effect.
    /// </summary>
    public sealed class SetShowWebVitalsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Overlay.setShowWebVitals";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the show
        /// </summary>
        [JsonPropertyName("show")]
        public bool Show
        {
            get;
            set;
        }
    }

    public sealed class SetShowWebVitalsCommandResponse : ICommandResponse<SetShowWebVitalsCommand>
    {
    }
}
namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns device's screen configuration. In headful mode, the physical screens configuration is returned,
    /// whereas in headless mode, a virtual headless screen configuration is provided instead.
    /// </summary>
    public sealed class GetScreenInfosCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Emulation.getScreenInfos";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class GetScreenInfosCommandResponse : ICommandResponse<GetScreenInfosCommand>
    {
        /// <summary>
        /// Gets or sets the screenInfos
        /// </summary>
        [JsonPropertyName("screenInfos")]
        public ScreenInfo[] ScreenInfos
        {
            get;
            set;
        }
    }
}
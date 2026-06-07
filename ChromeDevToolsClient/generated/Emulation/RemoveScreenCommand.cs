namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Remove screen from the device. Only supported in headless mode.
    /// </summary>
    public sealed class RemoveScreenCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Emulation.removeScreen";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the screenId
        /// </summary>
        [JsonPropertyName("screenId")]
        public string ScreenId
        {
            get;
            set;
        }
    }

    public sealed class RemoveScreenCommandResponse : ICommandResponse<RemoveScreenCommand>
    {
    }
}
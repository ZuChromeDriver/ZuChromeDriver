namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Set primary screen. Only supported in headless mode.
    /// Note that this changes the coordinate system origin to the top-left
    /// of the new primary screen, updating the bounds and work areas
    /// of all existing screens accordingly.
    /// </summary>
    public sealed class SetPrimaryScreenCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Emulation.setPrimaryScreen";
        
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

    public sealed class SetPrimaryScreenCommandResponse : ICommandResponse<SetPrimaryScreenCommand>
    {
    }
}
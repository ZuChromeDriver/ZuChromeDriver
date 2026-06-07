namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Requests that backend shows layout shift regions
    /// </summary>
    public sealed class SetShowLayoutShiftRegionsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Overlay.setShowLayoutShiftRegions";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// True for showing layout shift regions
        /// </summary>
        [JsonPropertyName("result")]
        public bool Result
        {
            get;
            set;
        }
    }

    public sealed class SetShowLayoutShiftRegionsCommandResponse : ICommandResponse<SetShowLayoutShiftRegionsCommand>
    {
    }
}
namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Add a dual screen device hinge
    /// </summary>
    public sealed class SetShowHingeCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Overlay.setShowHinge";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// hinge data, null means hideHinge
        /// </summary>
        [JsonPropertyName("hingeConfig")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public HingeConfig HingeConfig
        {
            get;
            set;
        }
    }

    public sealed class SetShowHingeCommandResponse : ICommandResponse<SetShowHingeCommand>
    {
    }
}
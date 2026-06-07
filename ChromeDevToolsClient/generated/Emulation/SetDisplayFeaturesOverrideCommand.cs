namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Start using the given display features to pupulate the Viewport Segments API.
    /// This override can also be set in setDeviceMetricsOverride().
    /// </summary>
    public sealed class SetDisplayFeaturesOverrideCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Emulation.setDisplayFeaturesOverride";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the features
        /// </summary>
        [JsonPropertyName("features")]
        public DisplayFeature[] Features
        {
            get;
            set;
        }
    }

    public sealed class SetDisplayFeaturesOverrideCommandResponse : ICommandResponse<SetDisplayFeaturesOverrideCommand>
    {
    }
}
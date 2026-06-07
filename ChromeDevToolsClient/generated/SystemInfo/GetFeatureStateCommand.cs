namespace Zu.ChromeDevTools.SystemInfo
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns information about the feature state.
    /// </summary>
    public sealed class GetFeatureStateCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "SystemInfo.getFeatureState";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the featureState
        /// </summary>
        [JsonPropertyName("featureState")]
        public string FeatureState
        {
            get;
            set;
        }
    }

    public sealed class GetFeatureStateCommandResponse : ICommandResponse<GetFeatureStateCommand>
    {
        /// <summary>
        /// Gets or sets the featureEnabled
        /// </summary>
        [JsonPropertyName("featureEnabled")]
        public bool FeatureEnabled
        {
            get;
            set;
        }
    }
}
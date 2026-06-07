namespace Zu.ChromeDevTools.PWA
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Launches the installed web app, or an url in the same web app instead of the
    /// default start url if it is provided. Returns a page Target.TargetID which
    /// can be used to attach to via Target.attachToTarget or similar APIs.
    /// </summary>
    public sealed class LaunchCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "PWA.launch";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the manifestId
        /// </summary>
        [JsonPropertyName("manifestId")]
        public string ManifestId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the url
        /// </summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Url
        {
            get;
            set;
        }
    }

    public sealed class LaunchCommandResponse : ICommandResponse<LaunchCommand>
    {
        /// <summary>
        /// ID of the tab target created as a result.
        ///</summary>
        [JsonPropertyName("targetId")]
        public string TargetId
        {
            get;
            set;
        }
    }
}
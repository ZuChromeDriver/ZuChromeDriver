namespace Zu.ChromeDevTools.Browser
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Allows a site to use privacy sandbox features that require enrollment
    /// without the site actually being enrolled. Only supported on page targets.
    /// </summary>
    public sealed class AddPrivacySandboxEnrollmentOverrideCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Browser.addPrivacySandboxEnrollmentOverride";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the url
        /// </summary>
        [JsonPropertyName("url")]
        public string Url
        {
            get;
            set;
        }
    }

    public sealed class AddPrivacySandboxEnrollmentOverrideCommandResponse : ICommandResponse<AddPrivacySandboxEnrollmentOverrideCommand>
    {
    }
}
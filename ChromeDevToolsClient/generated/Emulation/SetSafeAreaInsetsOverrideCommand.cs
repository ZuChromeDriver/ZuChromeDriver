namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Overrides the values for env(safe-area-inset-*) and env(safe-area-max-inset-*). Unset values will cause the
    /// respective variables to be undefined, even if previously overridden.
    /// </summary>
    public sealed class SetSafeAreaInsetsOverrideCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Emulation.setSafeAreaInsetsOverride";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the insets
        /// </summary>
        [JsonPropertyName("insets")]
        public SafeAreaInsets Insets
        {
            get;
            set;
        }
    }

    public sealed class SetSafeAreaInsetsOverrideCommandResponse : ICommandResponse<SetSafeAreaInsetsOverrideCommand>
    {
    }
}
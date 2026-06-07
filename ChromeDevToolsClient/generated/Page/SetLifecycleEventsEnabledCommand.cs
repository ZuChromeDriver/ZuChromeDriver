namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Controls whether page will emit lifecycle events.
    /// </summary>
    public sealed class SetLifecycleEventsEnabledCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.setLifecycleEventsEnabled";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// If true, starts emitting lifecycle events.
        /// </summary>
        [JsonPropertyName("enabled")]
        public bool Enabled
        {
            get;
            set;
        }
    }

    public sealed class SetLifecycleEventsEnabledCommandResponse : ICommandResponse<SetLifecycleEventsEnabledCommand>
    {
    }
}
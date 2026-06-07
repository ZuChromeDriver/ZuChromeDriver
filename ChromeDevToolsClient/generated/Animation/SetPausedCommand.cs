namespace Zu.ChromeDevTools.Animation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Sets the paused state of a set of animations.
    /// </summary>
    public sealed class SetPausedCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Animation.setPaused";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Animations to set the pause state of.
        /// </summary>
        [JsonPropertyName("animations")]
        public string[] Animations
        {
            get;
            set;
        }
        /// <summary>
        /// Paused state to set to.
        /// </summary>
        [JsonPropertyName("paused")]
        public bool Paused
        {
            get;
            set;
        }
    }

    public sealed class SetPausedCommandResponse : ICommandResponse<SetPausedCommand>
    {
    }
}
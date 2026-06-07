namespace Zu.ChromeDevTools.Animation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Seek a set of animations to a particular time within each animation.
    /// </summary>
    public sealed class SeekAnimationsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Animation.seekAnimations";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// List of animation ids to seek.
        /// </summary>
        [JsonPropertyName("animations")]
        public string[] Animations
        {
            get;
            set;
        }
        /// <summary>
        /// Set the current time of each animation.
        /// </summary>
        [JsonPropertyName("currentTime")]
        public double CurrentTime
        {
            get;
            set;
        }
    }

    public sealed class SeekAnimationsCommandResponse : ICommandResponse<SeekAnimationsCommand>
    {
    }
}
namespace Zu.ChromeDevTools.Animation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Releases a set of animations to no longer be manipulated.
    /// </summary>
    public sealed class ReleaseAnimationsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Animation.releaseAnimations";
        
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
    }

    public sealed class ReleaseAnimationsCommandResponse : ICommandResponse<ReleaseAnimationsCommand>
    {
    }
}
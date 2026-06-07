namespace Zu.ChromeDevTools.Animation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Gets the playback rate of the document timeline.
    /// </summary>
    public sealed class GetPlaybackRateCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Animation.getPlaybackRate";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class GetPlaybackRateCommandResponse : ICommandResponse<GetPlaybackRateCommand>
    {
        /// <summary>
        /// Playback rate for animations on page.
        ///</summary>
        [JsonPropertyName("playbackRate")]
        public double PlaybackRate
        {
            get;
            set;
        }
    }
}
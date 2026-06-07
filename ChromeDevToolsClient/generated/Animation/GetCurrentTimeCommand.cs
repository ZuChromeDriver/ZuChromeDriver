namespace Zu.ChromeDevTools.Animation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns the current time of the an animation.
    /// </summary>
    public sealed class GetCurrentTimeCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Animation.getCurrentTime";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Id of animation.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id
        {
            get;
            set;
        }
    }

    public sealed class GetCurrentTimeCommandResponse : ICommandResponse<GetCurrentTimeCommand>
    {
        /// <summary>
        /// Current time of the page.
        ///</summary>
        [JsonPropertyName("currentTime")]
        public double CurrentTime
        {
            get;
            set;
        }
    }
}
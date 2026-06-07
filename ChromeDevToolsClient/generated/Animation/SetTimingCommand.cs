namespace Zu.ChromeDevTools.Animation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Sets the timing of an animation node.
    /// </summary>
    public sealed class SetTimingCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Animation.setTiming";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Animation id.
        /// </summary>
        [JsonPropertyName("animationId")]
        public string AnimationId
        {
            get;
            set;
        }
        /// <summary>
        /// Duration of the animation.
        /// </summary>
        [JsonPropertyName("duration")]
        public double Duration
        {
            get;
            set;
        }
        /// <summary>
        /// Delay of the animation.
        /// </summary>
        [JsonPropertyName("delay")]
        public double Delay
        {
            get;
            set;
        }
    }

    public sealed class SetTimingCommandResponse : ICommandResponse<SetTimingCommand>
    {
    }
}
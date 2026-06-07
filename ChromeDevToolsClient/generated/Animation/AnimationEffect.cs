namespace Zu.ChromeDevTools.Animation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// AnimationEffect instance
    /// </summary>
    public sealed class AnimationEffect
    {
        /// <summary>
        /// `AnimationEffect`'s delay.
        ///</summary>
        [JsonPropertyName("delay")]
        public double Delay
        {
            get;
            set;
        }
        /// <summary>
        /// `AnimationEffect`'s end delay.
        ///</summary>
        [JsonPropertyName("endDelay")]
        public double EndDelay
        {
            get;
            set;
        }
        /// <summary>
        /// `AnimationEffect`'s iteration start.
        ///</summary>
        [JsonPropertyName("iterationStart")]
        public double IterationStart
        {
            get;
            set;
        }
        /// <summary>
        /// `AnimationEffect`'s iterations. Omitted if the value is infinite.
        ///</summary>
        [JsonPropertyName("iterations")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? Iterations
        {
            get;
            set;
        }
        /// <summary>
        /// `AnimationEffect`'s iteration duration.
        /// Milliseconds for time based animations and
        /// percentage [0 - 100] for scroll driven animations
        /// (i.e. when viewOrScrollTimeline exists).
        ///</summary>
        [JsonPropertyName("duration")]
        public double Duration
        {
            get;
            set;
        }
        /// <summary>
        /// `AnimationEffect`'s playback direction.
        ///</summary>
        [JsonPropertyName("direction")]
        public string Direction
        {
            get;
            set;
        }
        /// <summary>
        /// `AnimationEffect`'s fill mode.
        ///</summary>
        [JsonPropertyName("fill")]
        public string Fill
        {
            get;
            set;
        }
        /// <summary>
        /// `AnimationEffect`'s target node.
        ///</summary>
        [JsonPropertyName("backendNodeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? BackendNodeId
        {
            get;
            set;
        }
        /// <summary>
        /// `AnimationEffect`'s keyframes.
        ///</summary>
        [JsonPropertyName("keyframesRule")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public KeyframesRule KeyframesRule
        {
            get;
            set;
        }
        /// <summary>
        /// `AnimationEffect`'s timing function.
        ///</summary>
        [JsonPropertyName("easing")]
        public string Easing
        {
            get;
            set;
        }
    }
}
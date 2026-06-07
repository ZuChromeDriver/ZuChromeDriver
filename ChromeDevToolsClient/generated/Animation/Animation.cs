namespace Zu.ChromeDevTools.Animation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Animation instance.
    /// </summary>
    public sealed class Animation
    {
        /// <summary>
        /// `Animation`'s id.
        ///</summary>
        [JsonPropertyName("id")]
        public string Id
        {
            get;
            set;
        }
        /// <summary>
        /// `Animation`'s name.
        ///</summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// `Animation`'s internal paused state.
        ///</summary>
        [JsonPropertyName("pausedState")]
        public bool PausedState
        {
            get;
            set;
        }
        /// <summary>
        /// `Animation`'s play state.
        ///</summary>
        [JsonPropertyName("playState")]
        public string PlayState
        {
            get;
            set;
        }
        /// <summary>
        /// `Animation`'s playback rate.
        ///</summary>
        [JsonPropertyName("playbackRate")]
        public double PlaybackRate
        {
            get;
            set;
        }
        /// <summary>
        /// `Animation`'s start time.
        /// Milliseconds for time based animations and
        /// percentage [0 - 100] for scroll driven animations
        /// (i.e. when viewOrScrollTimeline exists).
        ///</summary>
        [JsonPropertyName("startTime")]
        public double StartTime
        {
            get;
            set;
        }
        /// <summary>
        /// `Animation`'s current time.
        ///</summary>
        [JsonPropertyName("currentTime")]
        public double CurrentTime
        {
            get;
            set;
        }
        /// <summary>
        /// Animation type of `Animation`.
        ///</summary>
        [JsonPropertyName("type")]
        public string Type
        {
            get;
            set;
        }
        /// <summary>
        /// `Animation`'s source animation node.
        ///</summary>
        [JsonPropertyName("source")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public AnimationEffect Source
        {
            get;
            set;
        }
        /// <summary>
        /// A unique ID for `Animation` representing the sources that triggered this CSS
        /// animation/transition.
        ///</summary>
        [JsonPropertyName("cssId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string CssId
        {
            get;
            set;
        }
        /// <summary>
        /// View or scroll timeline
        ///</summary>
        [JsonPropertyName("viewOrScrollTimeline")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ViewOrScrollTimeline ViewOrScrollTimeline
        {
            get;
            set;
        }
    }
}
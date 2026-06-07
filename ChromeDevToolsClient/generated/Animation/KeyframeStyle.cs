namespace Zu.ChromeDevTools.Animation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Keyframe Style
    /// </summary>
    public sealed class KeyframeStyle
    {
        /// <summary>
        /// Keyframe's time offset.
        ///</summary>
        [JsonPropertyName("offset")]
        public string Offset
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
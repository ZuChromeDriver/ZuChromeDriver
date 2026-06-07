namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// CSS keyframes rule representation.
    /// </summary>
    public sealed class CSSKeyframesRule
    {
        /// <summary>
        /// Animation name.
        ///</summary>
        [JsonPropertyName("animationName")]
        public Value AnimationName
        {
            get;
            set;
        }
        /// <summary>
        /// List of keyframes.
        ///</summary>
        [JsonPropertyName("keyframes")]
        public CSSKeyframeRule[] Keyframes
        {
            get;
            set;
        }
    }
}
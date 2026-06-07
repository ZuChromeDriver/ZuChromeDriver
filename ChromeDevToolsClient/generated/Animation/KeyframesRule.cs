namespace Zu.ChromeDevTools.Animation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Keyframes Rule
    /// </summary>
    public sealed class KeyframesRule
    {
        /// <summary>
        /// CSS keyframed animation's name.
        ///</summary>
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// List of animation keyframes.
        ///</summary>
        [JsonPropertyName("keyframes")]
        public KeyframeStyle[] Keyframes
        {
            get;
            set;
        }
    }
}
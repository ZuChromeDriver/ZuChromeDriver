namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Inherited CSS style collection for animated styles from ancestor node.
    /// </summary>
    public sealed class InheritedAnimatedStyleEntry
    {
        /// <summary>
        /// Styles coming from the animations of the ancestor, if any, in the style inheritance chain.
        ///</summary>
        [JsonPropertyName("animationStyles")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CSSAnimationStyle[] AnimationStyles
        {
            get;
            set;
        }
        /// <summary>
        /// The style coming from the transitions of the ancestor, if any, in the style inheritance chain.
        ///</summary>
        [JsonPropertyName("transitionsStyle")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CSSStyle TransitionsStyle
        {
            get;
            set;
        }
    }
}
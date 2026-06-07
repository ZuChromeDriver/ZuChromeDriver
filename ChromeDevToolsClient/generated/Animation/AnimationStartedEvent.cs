namespace Zu.ChromeDevTools.Animation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Event for animation that has been started.
    /// </summary>
    public sealed class AnimationStartedEvent : IEvent
    {
        /// <summary>
        /// Animation that was started.
        /// </summary>
        [JsonPropertyName("animation")]
        public Animation Animation
        {
            get;
            set;
        }
    }
}
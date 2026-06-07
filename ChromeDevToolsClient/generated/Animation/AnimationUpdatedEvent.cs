namespace Zu.ChromeDevTools.Animation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Event for animation that has been updated.
    /// </summary>
    public sealed class AnimationUpdatedEvent : IEvent
    {
        /// <summary>
        /// Animation that was updated.
        /// </summary>
        [JsonPropertyName("animation")]
        public Animation Animation
        {
            get;
            set;
        }
    }
}
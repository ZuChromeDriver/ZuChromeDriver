namespace Zu.ChromeDevTools.Animation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Event for when an animation has been cancelled.
    /// </summary>
    public sealed class AnimationCanceledEvent : IEvent
    {
        /// <summary>
        /// Id of the animation that was cancelled.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id
        {
            get;
            set;
        }
    }
}
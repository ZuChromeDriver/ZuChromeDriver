namespace Zu.ChromeDevTools.Animation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Event for each animation that has been created.
    /// </summary>
    public sealed class AnimationCreatedEvent : IEvent
    {
        /// <summary>
        /// Id of the animation that was created.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id
        {
            get;
            set;
        }
    }
}
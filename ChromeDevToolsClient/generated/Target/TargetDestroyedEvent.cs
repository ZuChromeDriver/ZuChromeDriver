namespace Zu.ChromeDevTools.Target
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Issued when a target is destroyed.
    /// </summary>
    public sealed class TargetDestroyedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the targetId
        /// </summary>
        [JsonPropertyName("targetId")]
        public string TargetId
        {
            get;
            set;
        }
    }
}
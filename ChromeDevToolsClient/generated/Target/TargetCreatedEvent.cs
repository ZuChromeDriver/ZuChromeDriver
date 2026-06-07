namespace Zu.ChromeDevTools.Target
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Issued when a possible inspection target is created.
    /// </summary>
    public sealed class TargetCreatedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the targetInfo
        /// </summary>
        [JsonPropertyName("targetInfo")]
        public TargetInfo TargetInfo
        {
            get;
            set;
        }
    }
}
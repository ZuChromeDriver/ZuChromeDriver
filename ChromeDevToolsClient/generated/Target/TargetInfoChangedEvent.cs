namespace Zu.ChromeDevTools.Target
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Issued when some information about a target has changed. This only happens between
    /// `targetCreated` and `targetDestroyed`.
    /// </summary>
    public sealed class TargetInfoChangedEvent : IEvent
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
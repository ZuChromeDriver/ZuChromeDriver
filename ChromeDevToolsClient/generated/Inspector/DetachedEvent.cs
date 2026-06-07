namespace Zu.ChromeDevTools.Inspector
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when remote debugging connection is about to be terminated. Contains detach reason.
    /// </summary>
    public sealed class DetachedEvent : IEvent
    {
        /// <summary>
        /// The reason why connection has been terminated.
        /// </summary>
        [JsonPropertyName("reason")]
        public string Reason
        {
            get;
            set;
        }
    }
}
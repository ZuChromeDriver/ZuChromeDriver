namespace Zu.ChromeDevTools.Security
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// The security state of the page changed.
    /// </summary>
    public sealed class VisibleSecurityStateChangedEvent : IEvent
    {
        /// <summary>
        /// Security state information about the page.
        /// </summary>
        [JsonPropertyName("visibleSecurityState")]
        public VisibleSecurityState VisibleSecurityState
        {
            get;
            set;
        }
    }
}
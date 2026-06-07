namespace Zu.ChromeDevTools.Target
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Issued when attached to target because of auto-attach or `attachToTarget` command.
    /// </summary>
    public sealed class AttachedToTargetEvent : IEvent
    {
        /// <summary>
        /// Identifier assigned to the session used to send/receive messages.
        /// </summary>
        [JsonPropertyName("sessionId")]
        public string SessionId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the targetInfo
        /// </summary>
        [JsonPropertyName("targetInfo")]
        public TargetInfo TargetInfo
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the waitingForDebugger
        /// </summary>
        [JsonPropertyName("waitingForDebugger")]
        public bool WaitingForDebugger
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.Target
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Notifies about a new protocol message received from the session (as reported in
    /// `attachedToTarget` event).
    /// </summary>
    public sealed class ReceivedMessageFromTargetEvent : IEvent
    {
        /// <summary>
        /// Identifier of a session which sends a message.
        /// </summary>
        [JsonPropertyName("sessionId")]
        public string SessionId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the message
        /// </summary>
        [JsonPropertyName("message")]
        public string Message
        {
            get;
            set;
        }
        /// <summary>
        /// Deprecated.
        /// </summary>
        [JsonPropertyName("targetId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string TargetId
        {
            get;
            set;
        }
    }
}
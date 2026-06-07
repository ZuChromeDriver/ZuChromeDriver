namespace Zu.ChromeDevTools.Target
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Issued when detached from target for any reason (including `detachFromTarget` command). Can be
    /// issued multiple times per target if multiple sessions have been attached to it.
    /// </summary>
    public sealed class DetachedFromTargetEvent : IEvent
    {
        /// <summary>
        /// Detached session identifier.
        /// </summary>
        [JsonPropertyName("sessionId")]
        public string SessionId
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
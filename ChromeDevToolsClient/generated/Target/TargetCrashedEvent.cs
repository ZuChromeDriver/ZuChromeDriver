namespace Zu.ChromeDevTools.Target
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Issued when a target has crashed.
    /// </summary>
    public sealed class TargetCrashedEvent : IEvent
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
        /// <summary>
        /// Termination status type.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status
        {
            get;
            set;
        }
        /// <summary>
        /// Termination error code.
        /// </summary>
        [JsonPropertyName("errorCode")]
        public long ErrorCode
        {
            get;
            set;
        }
    }
}
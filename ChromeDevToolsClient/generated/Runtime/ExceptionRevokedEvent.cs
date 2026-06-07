namespace Zu.ChromeDevTools.Runtime
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Issued when unhandled exception was revoked.
    /// </summary>
    public sealed class ExceptionRevokedEvent : IEvent
    {
        /// <summary>
        /// Reason describing why exception was revoked.
        /// </summary>
        [JsonPropertyName("reason")]
        public string Reason
        {
            get;
            set;
        }
        /// <summary>
        /// The id of revoked exception, as reported in `exceptionThrown`.
        /// </summary>
        [JsonPropertyName("exceptionId")]
        public long ExceptionId
        {
            get;
            set;
        }
    }
}
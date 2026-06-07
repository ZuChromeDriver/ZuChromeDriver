namespace Zu.ChromeDevTools.Runtime
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Issued when execution context is destroyed.
    /// </summary>
    public sealed class ExecutionContextDestroyedEvent : IEvent
    {
        /// <summary>
        /// Id of the destroyed context
        /// </summary>
        [JsonPropertyName("executionContextId")]
        public long ExecutionContextId
        {
            get;
            set;
        }
        /// <summary>
        /// Unique Id of the destroyed context
        /// </summary>
        [JsonPropertyName("executionContextUniqueId")]
        public string ExecutionContextUniqueId
        {
            get;
            set;
        }
    }
}
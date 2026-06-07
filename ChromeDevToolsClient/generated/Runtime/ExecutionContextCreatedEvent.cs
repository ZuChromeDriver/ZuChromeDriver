namespace Zu.ChromeDevTools.Runtime
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Issued when new execution context is created.
    /// </summary>
    public sealed class ExecutionContextCreatedEvent : IEvent
    {
        /// <summary>
        /// A newly created execution context.
        /// </summary>
        [JsonPropertyName("context")]
        public ExecutionContextDescription Context
        {
            get;
            set;
        }
    }
}
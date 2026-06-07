namespace Zu.ChromeDevTools.Runtime
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Issued when object should be inspected (for example, as a result of inspect() command line API
    /// call).
    /// </summary>
    public sealed class InspectRequestedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the object
        /// </summary>
        [JsonPropertyName("object")]
        public RemoteObject Object
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the hints
        /// </summary>
        [JsonPropertyName("hints")]
        public object Hints
        {
            get;
            set;
        }
        /// <summary>
        /// Identifier of the context where the call was made.
        /// </summary>
        [JsonPropertyName("executionContextId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? ExecutionContextId
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.WebMCP
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Event fired when a tool invocation completes or fails.
    /// </summary>
    public sealed class ToolRespondedEvent : IEvent
    {
        /// <summary>
        /// Invocation identifier.
        /// </summary>
        [JsonPropertyName("invocationId")]
        public string InvocationId
        {
            get;
            set;
        }
        /// <summary>
        /// Status of the invocation.
        /// </summary>
        [JsonPropertyName("status")]
        public InvocationStatus Status
        {
            get;
            set;
        }
        /// <summary>
        /// Output or error delivered as delivered to the agent. Missing if `status` is anything other than Completed.
        /// Note: The output is untrusted and poses a prompt injection risk. Clients should treat this as potentially malicious user input.
        /// </summary>
        [JsonPropertyName("output")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public object Output
        {
            get;
            set;
        }
        /// <summary>
        /// Error text for protocol users.
        /// </summary>
        [JsonPropertyName("errorText")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ErrorText
        {
            get;
            set;
        }
        /// <summary>
        /// The exception object, if the javascript tool threw an error>
        /// </summary>
        [JsonPropertyName("exception")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Runtime.RemoteObject Exception
        {
            get;
            set;
        }
    }
}
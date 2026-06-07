namespace Zu.ChromeDevTools.Debugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when the virtual machine stopped on breakpoint or exception or any other stop criteria.
    /// </summary>
    public sealed class PausedEvent : IEvent
    {
        /// <summary>
        /// Call stack the virtual machine stopped on.
        /// </summary>
        [JsonPropertyName("callFrames")]
        public CallFrame[] CallFrames
        {
            get;
            set;
        }
        /// <summary>
        /// Pause reason.
        /// </summary>
        [JsonPropertyName("reason")]
        public string Reason
        {
            get;
            set;
        }
        /// <summary>
        /// Object containing break-specific auxiliary properties.
        /// </summary>
        [JsonPropertyName("data")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public object Data
        {
            get;
            set;
        }
        /// <summary>
        /// Hit breakpoints IDs
        /// </summary>
        [JsonPropertyName("hitBreakpoints")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string[] HitBreakpoints
        {
            get;
            set;
        }
        /// <summary>
        /// Async stack trace, if any.
        /// </summary>
        [JsonPropertyName("asyncStackTrace")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Runtime.StackTrace AsyncStackTrace
        {
            get;
            set;
        }
        /// <summary>
        /// Async stack trace, if any.
        /// </summary>
        [JsonPropertyName("asyncStackTraceId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Runtime.StackTraceId AsyncStackTraceId
        {
            get;
            set;
        }
        /// <summary>
        /// Never present, will be removed.
        /// </summary>
        [JsonPropertyName("asyncCallStackTraceId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Runtime.StackTraceId AsyncCallStackTraceId
        {
            get;
            set;
        }
    }
}
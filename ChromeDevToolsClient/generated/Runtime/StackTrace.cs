namespace Zu.ChromeDevTools.Runtime
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Call frames for assertions or error messages.
    /// </summary>
    public sealed class StackTrace
    {
        /// <summary>
        /// String label of this stack trace. For async traces this may be a name of the function that
        /// initiated the async call.
        ///</summary>
        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Description
        {
            get;
            set;
        }
        /// <summary>
        /// JavaScript function name.
        ///</summary>
        [JsonPropertyName("callFrames")]
        public CallFrame[] CallFrames
        {
            get;
            set;
        }
        /// <summary>
        /// Asynchronous JavaScript stack trace that preceded this stack, if available.
        ///</summary>
        [JsonPropertyName("parent")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public StackTrace Parent
        {
            get;
            set;
        }
        /// <summary>
        /// Asynchronous JavaScript stack trace that preceded this stack, if available.
        ///</summary>
        [JsonPropertyName("parentId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public StackTraceId ParentId
        {
            get;
            set;
        }
    }
}
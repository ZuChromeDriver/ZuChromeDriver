namespace Zu.ChromeDevTools.Debugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Edits JavaScript source live.
    /// 
    /// In general, functions that are currently on the stack can not be edited with
    /// a single exception: If the edited function is the top-most stack frame and
    /// that is the only activation of that function on the stack. In this case
    /// the live edit will be successful and a `Debugger.restartFrame` for the
    /// top-most function is automatically triggered.
    /// </summary>
    public sealed class SetScriptSourceCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Debugger.setScriptSource";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Id of the script to edit.
        /// </summary>
        [JsonPropertyName("scriptId")]
        public string ScriptId
        {
            get;
            set;
        }
        /// <summary>
        /// New content of the script.
        /// </summary>
        [JsonPropertyName("scriptSource")]
        public string ScriptSource
        {
            get;
            set;
        }
        /// <summary>
        /// If true the change will not actually be applied. Dry run may be used to get result
        /// description without actually modifying the code.
        /// </summary>
        [JsonPropertyName("dryRun")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? DryRun
        {
            get;
            set;
        }
        /// <summary>
        /// If true, then `scriptSource` is allowed to change the function on top of the stack
        /// as long as the top-most stack frame is the only activation of that function.
        /// </summary>
        [JsonPropertyName("allowTopFrameEditing")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? AllowTopFrameEditing
        {
            get;
            set;
        }
    }

    public sealed class SetScriptSourceCommandResponse : ICommandResponse<SetScriptSourceCommand>
    {
        /// <summary>
        /// New stack trace in case editing has happened while VM was stopped.
        ///</summary>
        [JsonPropertyName("callFrames")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CallFrame[] CallFrames
        {
            get;
            set;
        }
        /// <summary>
        /// Whether current call stack  was modified after applying the changes.
        ///</summary>
        [JsonPropertyName("stackChanged")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? StackChanged
        {
            get;
            set;
        }
        /// <summary>
        /// Async stack trace, if any.
        ///</summary>
        [JsonPropertyName("asyncStackTrace")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Runtime.StackTrace AsyncStackTrace
        {
            get;
            set;
        }
        /// <summary>
        /// Async stack trace, if any.
        ///</summary>
        [JsonPropertyName("asyncStackTraceId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Runtime.StackTraceId AsyncStackTraceId
        {
            get;
            set;
        }
        /// <summary>
        /// Whether the operation was successful or not. Only `Ok` denotes a
        /// successful live edit while the other enum variants denote why
        /// the live edit failed.
        ///</summary>
        [JsonPropertyName("status")]
        public string Status
        {
            get;
            set;
        }
        /// <summary>
        /// Exception details if any. Only present when `status` is `CompileError`.
        ///</summary>
        [JsonPropertyName("exceptionDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Runtime.ExceptionDetails ExceptionDetails
        {
            get;
            set;
        }
    }
}
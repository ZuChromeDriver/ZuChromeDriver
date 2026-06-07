namespace Zu.ChromeDevTools.Runtime
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Compiles expression.
    /// </summary>
    public sealed class CompileScriptCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Runtime.compileScript";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Expression to compile.
        /// </summary>
        [JsonPropertyName("expression")]
        public string Expression
        {
            get;
            set;
        }
        /// <summary>
        /// Source url to be set for the script.
        /// </summary>
        [JsonPropertyName("sourceURL")]
        public string SourceURL
        {
            get;
            set;
        }
        /// <summary>
        /// Specifies whether the compiled script should be persisted.
        /// </summary>
        [JsonPropertyName("persistScript")]
        public bool PersistScript
        {
            get;
            set;
        }
        /// <summary>
        /// Specifies in which execution context to perform script run. If the parameter is omitted the
        /// evaluation will be performed in the context of the inspected page.
        /// </summary>
        [JsonPropertyName("executionContextId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? ExecutionContextId
        {
            get;
            set;
        }
    }

    public sealed class CompileScriptCommandResponse : ICommandResponse<CompileScriptCommand>
    {
        /// <summary>
        /// Id of the script.
        ///</summary>
        [JsonPropertyName("scriptId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ScriptId
        {
            get;
            set;
        }
        /// <summary>
        /// Exception details.
        ///</summary>
        [JsonPropertyName("exceptionDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ExceptionDetails ExceptionDetails
        {
            get;
            set;
        }
    }
}
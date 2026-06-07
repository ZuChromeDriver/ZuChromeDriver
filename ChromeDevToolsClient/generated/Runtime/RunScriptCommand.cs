namespace Zu.ChromeDevTools.Runtime
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Runs script with given id in a given context.
    /// </summary>
    public sealed class RunScriptCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Runtime.runScript";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Id of the script to run.
        /// </summary>
        [JsonPropertyName("scriptId")]
        public string ScriptId
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
        /// <summary>
        /// Symbolic group name that can be used to release multiple objects.
        /// </summary>
        [JsonPropertyName("objectGroup")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ObjectGroup
        {
            get;
            set;
        }
        /// <summary>
        /// In silent mode exceptions thrown during evaluation are not reported and do not pause
        /// execution. Overrides `setPauseOnException` state.
        /// </summary>
        [JsonPropertyName("silent")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Silent
        {
            get;
            set;
        }
        /// <summary>
        /// Determines whether Command Line API should be available during the evaluation.
        /// </summary>
        [JsonPropertyName("includeCommandLineAPI")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? IncludeCommandLineAPI
        {
            get;
            set;
        }
        /// <summary>
        /// Whether the result is expected to be a JSON object which should be sent by value.
        /// </summary>
        [JsonPropertyName("returnByValue")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? ReturnByValue
        {
            get;
            set;
        }
        /// <summary>
        /// Whether preview should be generated for the result.
        /// </summary>
        [JsonPropertyName("generatePreview")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? GeneratePreview
        {
            get;
            set;
        }
        /// <summary>
        /// Whether execution should `await` for resulting value and return once awaited promise is
        /// resolved.
        /// </summary>
        [JsonPropertyName("awaitPromise")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? AwaitPromise
        {
            get;
            set;
        }
    }

    public sealed class RunScriptCommandResponse : ICommandResponse<RunScriptCommand>
    {
        /// <summary>
        /// Run result.
        ///</summary>
        [JsonPropertyName("result")]
        public RemoteObject Result
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
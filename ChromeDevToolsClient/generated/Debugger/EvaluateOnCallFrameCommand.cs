namespace Zu.ChromeDevTools.Debugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Evaluates expression on a given call frame.
    /// </summary>
    public sealed class EvaluateOnCallFrameCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Debugger.evaluateOnCallFrame";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Call frame identifier to evaluate on.
        /// </summary>
        [JsonPropertyName("callFrameId")]
        public string CallFrameId
        {
            get;
            set;
        }
        /// <summary>
        /// Expression to evaluate.
        /// </summary>
        [JsonPropertyName("expression")]
        public string Expression
        {
            get;
            set;
        }
        /// <summary>
        /// String object group name to put result into (allows rapid releasing resulting object handles
        /// using `releaseObjectGroup`).
        /// </summary>
        [JsonPropertyName("objectGroup")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ObjectGroup
        {
            get;
            set;
        }
        /// <summary>
        /// Specifies whether command line API should be available to the evaluated expression, defaults
        /// to false.
        /// </summary>
        [JsonPropertyName("includeCommandLineAPI")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? IncludeCommandLineAPI
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
        /// Whether the result is expected to be a JSON object that should be sent by value.
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
        /// Whether to throw an exception if side effect cannot be ruled out during evaluation.
        /// </summary>
        [JsonPropertyName("throwOnSideEffect")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? ThrowOnSideEffect
        {
            get;
            set;
        }
        /// <summary>
        /// Terminate execution after timing out (number of milliseconds).
        /// </summary>
        [JsonPropertyName("timeout")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? Timeout
        {
            get;
            set;
        }
    }

    public sealed class EvaluateOnCallFrameCommandResponse : ICommandResponse<EvaluateOnCallFrameCommand>
    {
        /// <summary>
        /// Object wrapper for the evaluation result.
        ///</summary>
        [JsonPropertyName("result")]
        public Runtime.RemoteObject Result
        {
            get;
            set;
        }
        /// <summary>
        /// Exception details.
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
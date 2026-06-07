namespace Zu.ChromeDevTools.Runtime
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Add handler to promise with given promise object id.
    /// </summary>
    public sealed class AwaitPromiseCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Runtime.awaitPromise";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Identifier of the promise.
        /// </summary>
        [JsonPropertyName("promiseObjectId")]
        public string PromiseObjectId
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
    }

    public sealed class AwaitPromiseCommandResponse : ICommandResponse<AwaitPromiseCommand>
    {
        /// <summary>
        /// Promise result. Will contain rejected value if promise was rejected.
        ///</summary>
        [JsonPropertyName("result")]
        public RemoteObject Result
        {
            get;
            set;
        }
        /// <summary>
        /// Exception details if stack strace is available.
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
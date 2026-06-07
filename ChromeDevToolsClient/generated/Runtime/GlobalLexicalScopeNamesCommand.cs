namespace Zu.ChromeDevTools.Runtime
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns all let, const and class variables from global scope.
    /// </summary>
    public sealed class GlobalLexicalScopeNamesCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Runtime.globalLexicalScopeNames";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Specifies in which execution context to lookup global scope variables.
        /// </summary>
        [JsonPropertyName("executionContextId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? ExecutionContextId
        {
            get;
            set;
        }
    }

    public sealed class GlobalLexicalScopeNamesCommandResponse : ICommandResponse<GlobalLexicalScopeNamesCommand>
    {
        /// <summary>
        /// Gets or sets the names
        /// </summary>
        [JsonPropertyName("names")]
        public string[] Names
        {
            get;
            set;
        }
    }
}
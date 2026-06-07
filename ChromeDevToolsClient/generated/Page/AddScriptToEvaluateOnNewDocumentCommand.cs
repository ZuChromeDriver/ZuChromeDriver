namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Evaluates given script in every frame upon creation (before loading frame's scripts).
    /// </summary>
    public sealed class AddScriptToEvaluateOnNewDocumentCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.addScriptToEvaluateOnNewDocument";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the source
        /// </summary>
        [JsonPropertyName("source")]
        public string Source
        {
            get;
            set;
        }
        /// <summary>
        /// If specified, creates an isolated world with the given name and evaluates given script in it.
        /// This world name will be used as the ExecutionContextDescription::name when the corresponding
        /// event is emitted.
        /// </summary>
        [JsonPropertyName("worldName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string WorldName
        {
            get;
            set;
        }
        /// <summary>
        /// Specifies whether command line API should be available to the script, defaults
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
        /// If true, runs the script immediately on existing execution contexts or worlds.
        /// Default: false.
        /// </summary>
        [JsonPropertyName("runImmediately")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? RunImmediately
        {
            get;
            set;
        }
    }

    public sealed class AddScriptToEvaluateOnNewDocumentCommandResponse : ICommandResponse<AddScriptToEvaluateOnNewDocumentCommand>
    {
        /// <summary>
        /// Identifier of the added script.
        ///</summary>
        [JsonPropertyName("identifier")]
        public string Identifier
        {
            get;
            set;
        }
    }
}
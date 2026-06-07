namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Deprecated, please use addScriptToEvaluateOnNewDocument instead.
    /// </summary>
    public sealed class AddScriptToEvaluateOnLoadCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.addScriptToEvaluateOnLoad";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the scriptSource
        /// </summary>
        [JsonPropertyName("scriptSource")]
        public string ScriptSource
        {
            get;
            set;
        }
    }

    public sealed class AddScriptToEvaluateOnLoadCommandResponse : ICommandResponse<AddScriptToEvaluateOnLoadCommand>
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
namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Deprecated, please use removeScriptToEvaluateOnNewDocument instead.
    /// </summary>
    public sealed class RemoveScriptToEvaluateOnLoadCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.removeScriptToEvaluateOnLoad";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        [JsonPropertyName("identifier")]
        public string Identifier
        {
            get;
            set;
        }
    }

    public sealed class RemoveScriptToEvaluateOnLoadCommandResponse : ICommandResponse<RemoveScriptToEvaluateOnLoadCommand>
    {
    }
}
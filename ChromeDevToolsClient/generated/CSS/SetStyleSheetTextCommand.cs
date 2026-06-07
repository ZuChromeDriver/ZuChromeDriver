namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Sets the new stylesheet text.
    /// </summary>
    public sealed class SetStyleSheetTextCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "CSS.setStyleSheetText";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the styleSheetId
        /// </summary>
        [JsonPropertyName("styleSheetId")]
        public string StyleSheetId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the text
        /// </summary>
        [JsonPropertyName("text")]
        public string Text
        {
            get;
            set;
        }
    }

    public sealed class SetStyleSheetTextCommandResponse : ICommandResponse<SetStyleSheetTextCommand>
    {
        /// <summary>
        /// URL of source map associated with script (if any).
        ///</summary>
        [JsonPropertyName("sourceMapURL")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string SourceMapURL
        {
            get;
            set;
        }
    }
}
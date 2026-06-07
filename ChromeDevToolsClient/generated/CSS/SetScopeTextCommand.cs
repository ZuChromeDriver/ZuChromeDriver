namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Modifies the expression of a scope at-rule.
    /// </summary>
    public sealed class SetScopeTextCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "CSS.setScopeText";
        
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
        /// Gets or sets the range
        /// </summary>
        [JsonPropertyName("range")]
        public SourceRange Range
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

    public sealed class SetScopeTextCommandResponse : ICommandResponse<SetScopeTextCommand>
    {
        /// <summary>
        /// The resulting CSS Scope rule after modification.
        ///</summary>
        [JsonPropertyName("scope")]
        public CSSScope Scope
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Modifies the rule selector.
    /// </summary>
    public sealed class SetRuleSelectorCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "CSS.setRuleSelector";
        
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
        /// Gets or sets the selector
        /// </summary>
        [JsonPropertyName("selector")]
        public string Selector
        {
            get;
            set;
        }
    }

    public sealed class SetRuleSelectorCommandResponse : ICommandResponse<SetRuleSelectorCommand>
    {
        /// <summary>
        /// The resulting selector list after modification.
        ///</summary>
        [JsonPropertyName("selectorList")]
        public SelectorList SelectorList
        {
            get;
            set;
        }
    }
}
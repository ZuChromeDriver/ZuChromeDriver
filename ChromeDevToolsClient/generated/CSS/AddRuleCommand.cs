namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Inserts a new rule with the given `ruleText` in a stylesheet with given `styleSheetId`, at the
    /// position specified by `location`.
    /// </summary>
    public sealed class AddRuleCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "CSS.addRule";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// The css style sheet identifier where a new rule should be inserted.
        /// </summary>
        [JsonPropertyName("styleSheetId")]
        public string StyleSheetId
        {
            get;
            set;
        }
        /// <summary>
        /// The text of a new rule.
        /// </summary>
        [JsonPropertyName("ruleText")]
        public string RuleText
        {
            get;
            set;
        }
        /// <summary>
        /// Text position of a new rule in the target style sheet.
        /// </summary>
        [JsonPropertyName("location")]
        public SourceRange Location
        {
            get;
            set;
        }
        /// <summary>
        /// NodeId for the DOM node in whose context custom property declarations for registered properties should be
        /// validated. If omitted, declarations in the new rule text can only be validated statically, which may produce
        /// incorrect results if the declaration contains a var() for example.
        /// </summary>
        [JsonPropertyName("nodeForPropertySyntaxValidation")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? NodeForPropertySyntaxValidation
        {
            get;
            set;
        }
    }

    public sealed class AddRuleCommandResponse : ICommandResponse<AddRuleCommand>
    {
        /// <summary>
        /// The newly created rule.
        ///</summary>
        [JsonPropertyName("rule")]
        public CSSRule Rule
        {
            get;
            set;
        }
    }
}
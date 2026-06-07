namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Modifies the expression of a navigation at-rule.
    /// </summary>
    public sealed class SetNavigationTextCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "CSS.setNavigationText";
        
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

    public sealed class SetNavigationTextCommandResponse : ICommandResponse<SetNavigationTextCommand>
    {
        /// <summary>
        /// The resulting CSS Navigation rule after modification.
        ///</summary>
        [JsonPropertyName("navigation")]
        public CSSNavigation Navigation
        {
            get;
            set;
        }
    }
}
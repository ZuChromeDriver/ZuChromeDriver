namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Modifies the expression of a supports at-rule.
    /// </summary>
    public sealed class SetSupportsTextCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "CSS.setSupportsText";
        
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

    public sealed class SetSupportsTextCommandResponse : ICommandResponse<SetSupportsTextCommand>
    {
        /// <summary>
        /// The resulting CSS Supports rule after modification.
        ///</summary>
        [JsonPropertyName("supports")]
        public CSSSupports Supports
        {
            get;
            set;
        }
    }
}
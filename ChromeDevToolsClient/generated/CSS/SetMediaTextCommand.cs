namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Modifies the rule selector.
    /// </summary>
    public sealed class SetMediaTextCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "CSS.setMediaText";
        
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

    public sealed class SetMediaTextCommandResponse : ICommandResponse<SetMediaTextCommand>
    {
        /// <summary>
        /// The resulting CSS media rule after modification.
        ///</summary>
        [JsonPropertyName("media")]
        public CSSMedia Media
        {
            get;
            set;
        }
    }
}
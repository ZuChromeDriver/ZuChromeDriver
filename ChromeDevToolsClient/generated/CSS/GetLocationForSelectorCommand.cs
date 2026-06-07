namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Given a CSS selector text and a style sheet ID, getLocationForSelector
    /// returns an array of locations of the CSS selector in the style sheet.
    /// </summary>
    public sealed class GetLocationForSelectorCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "CSS.getLocationForSelector";
        
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
        /// Gets or sets the selectorText
        /// </summary>
        [JsonPropertyName("selectorText")]
        public string SelectorText
        {
            get;
            set;
        }
    }

    public sealed class GetLocationForSelectorCommandResponse : ICommandResponse<GetLocationForSelectorCommand>
    {
        /// <summary>
        /// Gets or sets the ranges
        /// </summary>
        [JsonPropertyName("ranges")]
        public SourceRange[] Ranges
        {
            get;
            set;
        }
    }
}
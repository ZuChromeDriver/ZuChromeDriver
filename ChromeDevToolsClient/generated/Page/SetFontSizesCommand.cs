namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Set default font sizes.
    /// </summary>
    public sealed class SetFontSizesCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.setFontSizes";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Specifies font sizes to set. If a font size is not specified, it won't be changed.
        /// </summary>
        [JsonPropertyName("fontSizes")]
        public FontSizes FontSizes
        {
            get;
            set;
        }
    }

    public sealed class SetFontSizesCommandResponse : ICommandResponse<SetFontSizesCommand>
    {
    }
}
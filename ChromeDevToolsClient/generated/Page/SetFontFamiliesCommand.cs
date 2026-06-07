namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Set generic font families.
    /// </summary>
    public sealed class SetFontFamiliesCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.setFontFamilies";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Specifies font families to set. If a font family is not specified, it won't be changed.
        /// </summary>
        [JsonPropertyName("fontFamilies")]
        public FontFamilies FontFamilies
        {
            get;
            set;
        }
        /// <summary>
        /// Specifies font families to set for individual scripts.
        /// </summary>
        [JsonPropertyName("forScripts")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ScriptFontFamilies[] ForScripts
        {
            get;
            set;
        }
    }

    public sealed class SetFontFamiliesCommandResponse : ICommandResponse<SetFontFamiliesCommand>
    {
    }
}
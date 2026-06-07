namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Font families collection for a script.
    /// </summary>
    public sealed class ScriptFontFamilies
    {
        /// <summary>
        /// Name of the script which these font families are defined for.
        ///</summary>
        [JsonPropertyName("script")]
        public string Script
        {
            get;
            set;
        }
        /// <summary>
        /// Generic font families collection for the script.
        ///</summary>
        [JsonPropertyName("fontFamilies")]
        public FontFamilies FontFamilies
        {
            get;
            set;
        }
    }
}
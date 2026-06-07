namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Information about amount of glyphs that were rendered with given font.
    /// </summary>
    public sealed class PlatformFontUsage
    {
        /// <summary>
        /// Font's family name reported by platform.
        ///</summary>
        [JsonPropertyName("familyName")]
        public string FamilyName
        {
            get;
            set;
        }
        /// <summary>
        /// Font's PostScript name reported by platform.
        ///</summary>
        [JsonPropertyName("postScriptName")]
        public string PostScriptName
        {
            get;
            set;
        }
        /// <summary>
        /// Indicates if the font was downloaded or resolved locally.
        ///</summary>
        [JsonPropertyName("isCustomFont")]
        public bool IsCustomFont
        {
            get;
            set;
        }
        /// <summary>
        /// Amount of glyphs that were rendered with this font.
        ///</summary>
        [JsonPropertyName("glyphCount")]
        public double GlyphCount
        {
            get;
            set;
        }
    }
}
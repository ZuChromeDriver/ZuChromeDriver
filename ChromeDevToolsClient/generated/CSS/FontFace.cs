namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Properties of a web font: https://www.w3.org/TR/2008/REC-CSS2-20080411/fonts.html#font-descriptions
    /// and additional information such as platformFontFamily and fontVariationAxes.
    /// </summary>
    public sealed class FontFace
    {
        /// <summary>
        /// The font-family.
        ///</summary>
        [JsonPropertyName("fontFamily")]
        public string FontFamily
        {
            get;
            set;
        }
        /// <summary>
        /// The font-style.
        ///</summary>
        [JsonPropertyName("fontStyle")]
        public string FontStyle
        {
            get;
            set;
        }
        /// <summary>
        /// The font-variant.
        ///</summary>
        [JsonPropertyName("fontVariant")]
        public string FontVariant
        {
            get;
            set;
        }
        /// <summary>
        /// The font-weight.
        ///</summary>
        [JsonPropertyName("fontWeight")]
        public string FontWeight
        {
            get;
            set;
        }
        /// <summary>
        /// The font-stretch.
        ///</summary>
        [JsonPropertyName("fontStretch")]
        public string FontStretch
        {
            get;
            set;
        }
        /// <summary>
        /// The font-display.
        ///</summary>
        [JsonPropertyName("fontDisplay")]
        public string FontDisplay
        {
            get;
            set;
        }
        /// <summary>
        /// The unicode-range.
        ///</summary>
        [JsonPropertyName("unicodeRange")]
        public string UnicodeRange
        {
            get;
            set;
        }
        /// <summary>
        /// The src.
        ///</summary>
        [JsonPropertyName("src")]
        public string Src
        {
            get;
            set;
        }
        /// <summary>
        /// The resolved platform font family
        ///</summary>
        [JsonPropertyName("platformFontFamily")]
        public string PlatformFontFamily
        {
            get;
            set;
        }
        /// <summary>
        /// Available variation settings (a.k.a. "axes").
        ///</summary>
        [JsonPropertyName("fontVariationAxes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public FontVariationAxis[] FontVariationAxes
        {
            get;
            set;
        }
    }
}
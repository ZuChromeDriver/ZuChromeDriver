namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// CSS property declaration data.
    /// </summary>
    public sealed class CSSProperty
    {
        /// <summary>
        /// The property name.
        ///</summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// The property value.
        ///</summary>
        [JsonPropertyName("value")]
        public string Value
        {
            get;
            set;
        }
        /// <summary>
        /// Whether the property has "!important" annotation (implies `false` if absent).
        ///</summary>
        [JsonPropertyName("important")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Important
        {
            get;
            set;
        }
        /// <summary>
        /// Whether the property is implicit (implies `false` if absent).
        ///</summary>
        [JsonPropertyName("implicit")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Implicit
        {
            get;
            set;
        }
        /// <summary>
        /// The full property text as specified in the style.
        ///</summary>
        [JsonPropertyName("text")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Text
        {
            get;
            set;
        }
        /// <summary>
        /// Whether the property is understood by the browser (implies `true` if absent).
        ///</summary>
        [JsonPropertyName("parsedOk")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? ParsedOk
        {
            get;
            set;
        }
        /// <summary>
        /// Whether the property is disabled by the user (present for source-based properties only).
        ///</summary>
        [JsonPropertyName("disabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Disabled
        {
            get;
            set;
        }
        /// <summary>
        /// The entire property range in the enclosing style declaration (if available).
        ///</summary>
        [JsonPropertyName("range")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public SourceRange Range
        {
            get;
            set;
        }
        /// <summary>
        /// Parsed longhand components of this property if it is a shorthand.
        /// This field will be empty if the given property is not a shorthand.
        ///</summary>
        [JsonPropertyName("longhandProperties")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CSSProperty[] LonghandProperties
        {
            get;
            set;
        }
    }
}
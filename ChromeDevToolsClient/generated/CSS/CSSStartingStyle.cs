namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// CSS Starting Style at-rule descriptor.
    /// </summary>
    public sealed class CSSStartingStyle
    {
        /// <summary>
        /// The associated rule header range in the enclosing stylesheet (if
        /// available).
        ///</summary>
        [JsonPropertyName("range")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public SourceRange Range
        {
            get;
            set;
        }
        /// <summary>
        /// Identifier of the stylesheet containing this object (if exists).
        ///</summary>
        [JsonPropertyName("styleSheetId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string StyleSheetId
        {
            get;
            set;
        }
    }
}
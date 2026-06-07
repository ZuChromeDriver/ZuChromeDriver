namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents the provenance of an ad resource or element. Only one of
    /// `filterlistRule` or `adScriptAncestry` can be set. If `filterlistRule`
    /// is provided, the resource URL directly matches a filter list rule. If
    /// `adScriptAncestry` is provided, an ad script initiated the resource fetch or
    /// appended the element to the DOM. If neither is provided, the entity is
    /// known to be an ad, but provenance tracking information is unavailable.
    /// </summary>
    public sealed class AdProvenance
    {
        /// <summary>
        /// The filterlist rule that matched, if any.
        ///</summary>
        [JsonPropertyName("filterlistRule")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string FilterlistRule
        {
            get;
            set;
        }
        /// <summary>
        /// The script ancestry that created the ad, if any.
        ///</summary>
        [JsonPropertyName("adScriptAncestry")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public AdAncestry AdScriptAncestry
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.Accessibility
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Enum of possible property sources.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AXValueSourceType
    {
        [JsonStringEnumMemberName("attribute")]
        Attribute,
        [JsonStringEnumMemberName("implicit")]
        Implicit,
        [JsonStringEnumMemberName("style")]
        Style,
        [JsonStringEnumMemberName("contents")]
        Contents,
        [JsonStringEnumMemberName("placeholder")]
        Placeholder,
        [JsonStringEnumMemberName("relatedElement")]
        RelatedElement,
    }
}
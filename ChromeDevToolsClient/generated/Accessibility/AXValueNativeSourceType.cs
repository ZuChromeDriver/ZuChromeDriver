namespace Zu.ChromeDevTools.Accessibility
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Enum of possible native property sources (as a subtype of a particular AXValueSourceType).
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AXValueNativeSourceType
    {
        [JsonStringEnumMemberName("description")]
        Description,
        [JsonStringEnumMemberName("figcaption")]
        Figcaption,
        [JsonStringEnumMemberName("label")]
        Label,
        [JsonStringEnumMemberName("labelfor")]
        Labelfor,
        [JsonStringEnumMemberName("labelwrapped")]
        Labelwrapped,
        [JsonStringEnumMemberName("legend")]
        Legend,
        [JsonStringEnumMemberName("rubyannotation")]
        Rubyannotation,
        [JsonStringEnumMemberName("tablecaption")]
        Tablecaption,
        [JsonStringEnumMemberName("title")]
        Title,
        [JsonStringEnumMemberName("other")]
        Other,
    }
}
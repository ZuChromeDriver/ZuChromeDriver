namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ElementAccessibilityIssueReason
    {
        [JsonStringEnumMemberName("DisallowedSelectChild")]
        DisallowedSelectChild,
        [JsonStringEnumMemberName("DisallowedOptGroupChild")]
        DisallowedOptGroupChild,
        [JsonStringEnumMemberName("NonPhrasingContentOptionChild")]
        NonPhrasingContentOptionChild,
        [JsonStringEnumMemberName("InteractiveContentOptionChild")]
        InteractiveContentOptionChild,
        [JsonStringEnumMemberName("InteractiveContentLegendChild")]
        InteractiveContentLegendChild,
        [JsonStringEnumMemberName("InteractiveContentSummaryDescendant")]
        InteractiveContentSummaryDescendant,
    }
}
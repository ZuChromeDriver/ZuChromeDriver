namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PropertyRuleIssueReason
    {
        [JsonStringEnumMemberName("InvalidSyntax")]
        InvalidSyntax,
        [JsonStringEnumMemberName("InvalidInitialValue")]
        InvalidInitialValue,
        [JsonStringEnumMemberName("InvalidInherits")]
        InvalidInherits,
        [JsonStringEnumMemberName("InvalidName")]
        InvalidName,
    }
}
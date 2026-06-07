namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ClientHintIssueReason
    {
        [JsonStringEnumMemberName("MetaTagAllowListInvalidOrigin")]
        MetaTagAllowListInvalidOrigin,
        [JsonStringEnumMemberName("MetaTagModifiedHTML")]
        MetaTagModifiedHTML,
    }
}
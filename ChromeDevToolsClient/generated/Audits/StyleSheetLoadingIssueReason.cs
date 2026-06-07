namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StyleSheetLoadingIssueReason
    {
        [JsonStringEnumMemberName("LateImportRule")]
        LateImportRule,
        [JsonStringEnumMemberName("RequestFailed")]
        RequestFailed,
    }
}
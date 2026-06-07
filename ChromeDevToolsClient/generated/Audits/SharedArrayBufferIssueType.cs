namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SharedArrayBufferIssueType
    {
        [JsonStringEnumMemberName("TransferIssue")]
        TransferIssue,
        [JsonStringEnumMemberName("CreationIssue")]
        CreationIssue,
    }
}
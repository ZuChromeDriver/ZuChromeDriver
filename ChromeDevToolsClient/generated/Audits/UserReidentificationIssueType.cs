namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserReidentificationIssueType
    {
        [JsonStringEnumMemberName("BlockedFrameNavigation")]
        BlockedFrameNavigation,
        [JsonStringEnumMemberName("BlockedSubresource")]
        BlockedSubresource,
        [JsonStringEnumMemberName("NoisedCanvasReadback")]
        NoisedCanvasReadback,
    }
}
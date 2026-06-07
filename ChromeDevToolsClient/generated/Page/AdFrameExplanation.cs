namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AdFrameExplanation
    {
        [JsonStringEnumMemberName("ParentIsAd")]
        ParentIsAd,
        [JsonStringEnumMemberName("CreatedByAdScript")]
        CreatedByAdScript,
        [JsonStringEnumMemberName("MatchedBlockingRule")]
        MatchedBlockingRule,
    }
}
namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OriginTrialUsageRestriction
    {
        [JsonStringEnumMemberName("None")]
        None,
        [JsonStringEnumMemberName("Subset")]
        Subset,
    }
}
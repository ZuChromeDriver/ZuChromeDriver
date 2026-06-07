namespace Zu.ChromeDevTools.Security
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SafetyTipStatus
    {
        [JsonStringEnumMemberName("badReputation")]
        BadReputation,
        [JsonStringEnumMemberName("lookalike")]
        Lookalike,
    }
}
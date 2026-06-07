namespace Zu.ChromeDevTools.Preload
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RuleSetErrorType
    {
        [JsonStringEnumMemberName("SourceIsNotJsonObject")]
        SourceIsNotJsonObject,
        [JsonStringEnumMemberName("InvalidRulesSkipped")]
        InvalidRulesSkipped,
        [JsonStringEnumMemberName("InvalidRulesetLevelTag")]
        InvalidRulesetLevelTag,
    }
}
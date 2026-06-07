namespace Zu.ChromeDevTools.WebAudio
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Enum of AudioParam::AutomationRate from the spec
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AutomationRate
    {
        [JsonStringEnumMemberName("a-rate")]
        ARate,
        [JsonStringEnumMemberName("k-rate")]
        KRate,
    }
}
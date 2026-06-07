namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PressureState
    {
        [JsonStringEnumMemberName("nominal")]
        Nominal,
        [JsonStringEnumMemberName("fair")]
        Fair,
        [JsonStringEnumMemberName("serious")]
        Serious,
        [JsonStringEnumMemberName("critical")]
        Critical,
    }
}
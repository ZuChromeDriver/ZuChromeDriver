namespace Zu.ChromeDevTools.Memory
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Memory pressure level.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PressureLevel
    {
        [JsonStringEnumMemberName("moderate")]
        Moderate,
        [JsonStringEnumMemberName("critical")]
        Critical,
    }
}
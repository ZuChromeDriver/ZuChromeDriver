namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Loading priority of a resource request.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ResourcePriority
    {
        [JsonStringEnumMemberName("VeryLow")]
        VeryLow,
        [JsonStringEnumMemberName("Low")]
        Low,
        [JsonStringEnumMemberName("Medium")]
        Medium,
        [JsonStringEnumMemberName("High")]
        High,
        [JsonStringEnumMemberName("VeryHigh")]
        VeryHigh,
    }
}
namespace Zu.ChromeDevTools.SmartCardEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Maps to the |SCARD_SHARE_*| values.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ShareMode
    {
        [JsonStringEnumMemberName("shared")]
        Shared,
        [JsonStringEnumMemberName("exclusive")]
        Exclusive,
        [JsonStringEnumMemberName("direct")]
        Direct,
    }
}
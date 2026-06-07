namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Enum of image types that can be disabled.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DisabledImageType
    {
        [JsonStringEnumMemberName("avif")]
        Avif,
        [JsonStringEnumMemberName("jxl")]
        Jxl,
        [JsonStringEnumMemberName("webp")]
        Webp,
    }
}
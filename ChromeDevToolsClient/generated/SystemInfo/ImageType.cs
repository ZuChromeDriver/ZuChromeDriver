namespace Zu.ChromeDevTools.SystemInfo
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Image format of a given image.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ImageType
    {
        [JsonStringEnumMemberName("jpeg")]
        Jpeg,
        [JsonStringEnumMemberName("webp")]
        Webp,
        [JsonStringEnumMemberName("unknown")]
        Unknown,
    }
}
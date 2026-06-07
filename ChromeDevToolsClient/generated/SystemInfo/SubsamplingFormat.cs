namespace Zu.ChromeDevTools.SystemInfo
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// YUV subsampling type of the pixels of a given image.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SubsamplingFormat
    {
        [JsonStringEnumMemberName("yuv420")]
        Yuv420,
        [JsonStringEnumMemberName("yuv422")]
        Yuv422,
        [JsonStringEnumMemberName("yuv444")]
        Yuv444,
    }
}
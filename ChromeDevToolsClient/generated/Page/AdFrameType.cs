namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Indicates whether a frame has been identified as an ad.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AdFrameType
    {
        [JsonStringEnumMemberName("none")]
        None,
        [JsonStringEnumMemberName("child")]
        Child,
        [JsonStringEnumMemberName("root")]
        Root,
    }
}
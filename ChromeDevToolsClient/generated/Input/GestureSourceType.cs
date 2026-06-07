namespace Zu.ChromeDevTools.Input
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GestureSourceType
    {
        [JsonStringEnumMemberName("default")]
        Default,
        [JsonStringEnumMemberName("touch")]
        Touch,
        [JsonStringEnumMemberName("mouse")]
        Mouse,
    }
}
namespace Zu.ChromeDevTools.Input
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MouseButton
    {
        [JsonStringEnumMemberName("none")]
        None,
        [JsonStringEnumMemberName("left")]
        Left,
        [JsonStringEnumMemberName("middle")]
        Middle,
        [JsonStringEnumMemberName("right")]
        Right,
        [JsonStringEnumMemberName("back")]
        Back,
        [JsonStringEnumMemberName("forward")]
        Forward,
    }
}
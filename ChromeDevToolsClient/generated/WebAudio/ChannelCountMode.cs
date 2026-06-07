namespace Zu.ChromeDevTools.WebAudio
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Enum of AudioNode::ChannelCountMode from the spec
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ChannelCountMode
    {
        [JsonStringEnumMemberName("clamped-max")]
        ClampedMax,
        [JsonStringEnumMemberName("explicit")]
        Explicit,
        [JsonStringEnumMemberName("max")]
        Max,
    }
}
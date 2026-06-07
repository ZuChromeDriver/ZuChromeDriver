namespace Zu.ChromeDevTools.WebAudio
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Enum of AudioNode::ChannelInterpretation from the spec
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ChannelInterpretation
    {
        [JsonStringEnumMemberName("discrete")]
        Discrete,
        [JsonStringEnumMemberName("speakers")]
        Speakers,
    }
}
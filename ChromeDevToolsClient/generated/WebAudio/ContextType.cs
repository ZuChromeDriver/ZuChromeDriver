namespace Zu.ChromeDevTools.WebAudio
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Enum of BaseAudioContext types
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ContextType
    {
        [JsonStringEnumMemberName("realtime")]
        Realtime,
        [JsonStringEnumMemberName("offline")]
        Offline,
    }
}
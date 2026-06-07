namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ContrastAlgorithm
    {
        [JsonStringEnumMemberName("aa")]
        Aa,
        [JsonStringEnumMemberName("aaa")]
        Aaa,
        [JsonStringEnumMemberName("apca")]
        Apca,
    }
}
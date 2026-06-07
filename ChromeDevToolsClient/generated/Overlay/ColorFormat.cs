namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ColorFormat
    {
        [JsonStringEnumMemberName("rgb")]
        Rgb,
        [JsonStringEnumMemberName("hsl")]
        Hsl,
        [JsonStringEnumMemberName("hwb")]
        Hwb,
        [JsonStringEnumMemberName("hex")]
        Hex,
    }
}
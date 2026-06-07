namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PressureSource
    {
        [JsonStringEnumMemberName("cpu")]
        Cpu,
    }
}
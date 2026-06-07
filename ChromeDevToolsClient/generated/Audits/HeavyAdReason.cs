namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum HeavyAdReason
    {
        [JsonStringEnumMemberName("NetworkTotalLimit")]
        NetworkTotalLimit,
        [JsonStringEnumMemberName("CpuTotalLimit")]
        CpuTotalLimit,
        [JsonStringEnumMemberName("CpuPeakLimit")]
        CpuPeakLimit,
    }
}
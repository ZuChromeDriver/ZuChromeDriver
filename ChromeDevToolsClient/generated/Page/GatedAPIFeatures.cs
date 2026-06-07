namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GatedAPIFeatures
    {
        [JsonStringEnumMemberName("SharedArrayBuffers")]
        SharedArrayBuffers,
        [JsonStringEnumMemberName("SharedArrayBuffersTransferAllowed")]
        SharedArrayBuffersTransferAllowed,
        [JsonStringEnumMemberName("PerformanceMeasureMemory")]
        PerformanceMeasureMemory,
        [JsonStringEnumMemberName("PerformanceProfile")]
        PerformanceProfile,
    }
}
namespace Zu.ChromeDevTools.ServiceWorker
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ServiceWorkerVersionRunningStatus
    {
        [JsonStringEnumMemberName("stopped")]
        Stopped,
        [JsonStringEnumMemberName("starting")]
        Starting,
        [JsonStringEnumMemberName("running")]
        Running,
        [JsonStringEnumMemberName("stopping")]
        Stopping,
    }
}
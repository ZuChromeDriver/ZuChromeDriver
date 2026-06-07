namespace Zu.ChromeDevTools.ServiceWorker
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ServiceWorkerVersionStatus
    {
        [JsonStringEnumMemberName("new")]
        New,
        [JsonStringEnumMemberName("installing")]
        Installing,
        [JsonStringEnumMemberName("installed")]
        Installed,
        [JsonStringEnumMemberName("activating")]
        Activating,
        [JsonStringEnumMemberName("activated")]
        Activated,
        [JsonStringEnumMemberName("redundant")]
        Redundant,
    }
}
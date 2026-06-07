namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StorageBucketsDurability
    {
        [JsonStringEnumMemberName("relaxed")]
        Relaxed,
        [JsonStringEnumMemberName("strict")]
        Strict,
    }
}
namespace Zu.ChromeDevTools.Extensions
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Storage areas.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StorageArea
    {
        [JsonStringEnumMemberName("session")]
        Session,
        [JsonStringEnumMemberName("local")]
        Local,
        [JsonStringEnumMemberName("sync")]
        Sync,
        [JsonStringEnumMemberName("managed")]
        Managed,
    }
}
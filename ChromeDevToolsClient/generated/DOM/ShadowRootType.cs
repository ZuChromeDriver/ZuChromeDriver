namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Shadow root type.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ShadowRootType
    {
        [JsonStringEnumMemberName("user-agent")]
        UserAgent,
        [JsonStringEnumMemberName("open")]
        Open,
        [JsonStringEnumMemberName("closed")]
        Closed,
    }
}
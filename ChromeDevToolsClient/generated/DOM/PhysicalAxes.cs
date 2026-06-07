namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// ContainerSelector physical axes
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PhysicalAxes
    {
        [JsonStringEnumMemberName("Horizontal")]
        Horizontal,
        [JsonStringEnumMemberName("Vertical")]
        Vertical,
        [JsonStringEnumMemberName("Both")]
        Both,
    }
}
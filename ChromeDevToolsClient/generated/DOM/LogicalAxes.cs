namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// ContainerSelector logical axes
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum LogicalAxes
    {
        [JsonStringEnumMemberName("Inline")]
        Inline,
        [JsonStringEnumMemberName("Block")]
        Block,
        [JsonStringEnumMemberName("Both")]
        Both,
    }
}
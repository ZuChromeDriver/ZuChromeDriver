namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Physical scroll orientation
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ScrollOrientation
    {
        [JsonStringEnumMemberName("horizontal")]
        Horizontal,
        [JsonStringEnumMemberName("vertical")]
        Vertical,
    }
}
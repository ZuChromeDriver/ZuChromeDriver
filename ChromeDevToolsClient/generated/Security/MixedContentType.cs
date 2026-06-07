namespace Zu.ChromeDevTools.Security
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// A description of mixed content (HTTP resources on HTTPS pages), as defined by
    /// https://www.w3.org/TR/mixed-content/#categories
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MixedContentType
    {
        [JsonStringEnumMemberName("blockable")]
        Blockable,
        [JsonStringEnumMemberName("optionally-blockable")]
        OptionallyBlockable,
        [JsonStringEnumMemberName("none")]
        None,
    }
}
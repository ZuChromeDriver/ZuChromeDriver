namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// The render-blocking behavior of a resource request.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RenderBlockingBehavior
    {
        [JsonStringEnumMemberName("Blocking")]
        Blocking,
        [JsonStringEnumMemberName("InBodyParserBlocking")]
        InBodyParserBlocking,
        [JsonStringEnumMemberName("NonBlocking")]
        NonBlocking,
        [JsonStringEnumMemberName("NonBlockingDynamic")]
        NonBlockingDynamic,
        [JsonStringEnumMemberName("PotentiallyBlocking")]
        PotentiallyBlocking,
    }
}
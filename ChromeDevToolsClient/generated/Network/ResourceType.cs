namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Resource type as it was perceived by the rendering engine.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ResourceType
    {
        [JsonStringEnumMemberName("Document")]
        Document,
        [JsonStringEnumMemberName("Stylesheet")]
        Stylesheet,
        [JsonStringEnumMemberName("Image")]
        Image,
        [JsonStringEnumMemberName("Media")]
        Media,
        [JsonStringEnumMemberName("Font")]
        Font,
        [JsonStringEnumMemberName("Script")]
        Script,
        [JsonStringEnumMemberName("TextTrack")]
        TextTrack,
        [JsonStringEnumMemberName("XHR")]
        XHR,
        [JsonStringEnumMemberName("Fetch")]
        Fetch,
        [JsonStringEnumMemberName("Prefetch")]
        Prefetch,
        [JsonStringEnumMemberName("EventSource")]
        EventSource,
        [JsonStringEnumMemberName("WebSocket")]
        WebSocket,
        [JsonStringEnumMemberName("Manifest")]
        Manifest,
        [JsonStringEnumMemberName("SignedExchange")]
        SignedExchange,
        [JsonStringEnumMemberName("Ping")]
        Ping,
        [JsonStringEnumMemberName("CSPViolationReport")]
        CSPViolationReport,
        [JsonStringEnumMemberName("Preflight")]
        Preflight,
        [JsonStringEnumMemberName("FedCM")]
        FedCM,
        [JsonStringEnumMemberName("Other")]
        Other,
    }
}
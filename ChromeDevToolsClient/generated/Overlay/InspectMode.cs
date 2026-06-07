namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum InspectMode
    {
        [JsonStringEnumMemberName("searchForNode")]
        SearchForNode,
        [JsonStringEnumMemberName("searchForUAShadowDOM")]
        SearchForUAShadowDOM,
        [JsonStringEnumMemberName("captureAreaScreenshot")]
        CaptureAreaScreenshot,
        [JsonStringEnumMemberName("none")]
        None,
    }
}
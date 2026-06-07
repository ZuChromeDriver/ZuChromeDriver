namespace Zu.ChromeDevTools.DOMDebugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// DOM breakpoint type.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DOMBreakpointType
    {
        [JsonStringEnumMemberName("subtree-modified")]
        SubtreeModified,
        [JsonStringEnumMemberName("attribute-modified")]
        AttributeModified,
        [JsonStringEnumMemberName("node-removed")]
        NodeRemoved,
    }
}
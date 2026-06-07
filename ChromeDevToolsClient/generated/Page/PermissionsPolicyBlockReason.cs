namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Reason for a permissions policy feature to be disabled.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PermissionsPolicyBlockReason
    {
        [JsonStringEnumMemberName("Header")]
        Header,
        [JsonStringEnumMemberName("IframeAttribute")]
        IframeAttribute,
        [JsonStringEnumMemberName("InFencedFrameTree")]
        InFencedFrameTree,
        [JsonStringEnumMemberName("InIsolatedApp")]
        InIsolatedApp,
    }
}
namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Indicates whether the frame is cross-origin isolated and why it is the case.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CrossOriginIsolatedContextType
    {
        [JsonStringEnumMemberName("Isolated")]
        Isolated,
        [JsonStringEnumMemberName("NotIsolated")]
        NotIsolated,
        [JsonStringEnumMemberName("NotIsolatedFeatureDisabled")]
        NotIsolatedFeatureDisabled,
    }
}
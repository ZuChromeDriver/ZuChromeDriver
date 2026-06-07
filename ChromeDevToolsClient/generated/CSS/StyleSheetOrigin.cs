namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Stylesheet type: "injected" for stylesheets injected via extension, "user-agent" for user-agent
    /// stylesheets, "inspector" for stylesheets created by the inspector (i.e. those holding the "via
    /// inspector" rules), "regular" for regular stylesheets.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StyleSheetOrigin
    {
        [JsonStringEnumMemberName("injected")]
        Injected,
        [JsonStringEnumMemberName("user-agent")]
        UserAgent,
        [JsonStringEnumMemberName("inspector")]
        Inspector,
        [JsonStringEnumMemberName("regular")]
        Regular,
    }
}
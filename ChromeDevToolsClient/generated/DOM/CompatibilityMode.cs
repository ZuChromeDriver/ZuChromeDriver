namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Document compatibility mode.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CompatibilityMode
    {
        [JsonStringEnumMemberName("QuirksMode")]
        QuirksMode,
        [JsonStringEnumMemberName("LimitedQuirksMode")]
        LimitedQuirksMode,
        [JsonStringEnumMemberName("NoQuirksMode")]
        NoQuirksMode,
    }
}
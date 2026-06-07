namespace Zu.ChromeDevTools.Debugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Enum of possible script languages.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ScriptLanguage
    {
        [JsonStringEnumMemberName("JavaScript")]
        JavaScript,
        [JsonStringEnumMemberName("WebAssembly")]
        WebAssembly,
    }
}
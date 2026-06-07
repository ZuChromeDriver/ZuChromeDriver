namespace Zu.ChromeDevTools.Preload
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Corresponds to mojom::SpeculationTargetHint.
    /// See https://github.com/WICG/nav-speculation/blob/main/triggers.md#window-name-targeting-hints
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SpeculationTargetHint
    {
        [JsonStringEnumMemberName("Blank")]
        Blank,
        [JsonStringEnumMemberName("Self")]
        Self,
    }
}
namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Transition type.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TransitionType
    {
        [JsonStringEnumMemberName("link")]
        Link,
        [JsonStringEnumMemberName("typed")]
        Typed,
        [JsonStringEnumMemberName("address_bar")]
        Address_bar,
        [JsonStringEnumMemberName("auto_bookmark")]
        Auto_bookmark,
        [JsonStringEnumMemberName("auto_subframe")]
        Auto_subframe,
        [JsonStringEnumMemberName("manual_subframe")]
        Manual_subframe,
        [JsonStringEnumMemberName("generated")]
        Generated,
        [JsonStringEnumMemberName("auto_toplevel")]
        Auto_toplevel,
        [JsonStringEnumMemberName("form_submit")]
        Form_submit,
        [JsonStringEnumMemberName("reload")]
        Reload,
        [JsonStringEnumMemberName("keyword")]
        Keyword,
        [JsonStringEnumMemberName("keyword_generated")]
        Keyword_generated,
        [JsonStringEnumMemberName("other")]
        Other,
    }
}
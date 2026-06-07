namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Enum indicating the type of a CSS rule, used to represent the order of a style rule's ancestors.
    /// This list only contains rule types that are collected during the ancestor rule collection.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CSSRuleType
    {
        [JsonStringEnumMemberName("MediaRule")]
        MediaRule,
        [JsonStringEnumMemberName("SupportsRule")]
        SupportsRule,
        [JsonStringEnumMemberName("ContainerRule")]
        ContainerRule,
        [JsonStringEnumMemberName("LayerRule")]
        LayerRule,
        [JsonStringEnumMemberName("ScopeRule")]
        ScopeRule,
        [JsonStringEnumMemberName("StyleRule")]
        StyleRule,
        [JsonStringEnumMemberName("StartingStyleRule")]
        StartingStyleRule,
        [JsonStringEnumMemberName("NavigationRule")]
        NavigationRule,
    }
}
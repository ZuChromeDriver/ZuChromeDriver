namespace Zu.ChromeDevTools.Accessibility
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Enum of possible property types.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AXValueType
    {
        [JsonStringEnumMemberName("boolean")]
        Boolean,
        [JsonStringEnumMemberName("tristate")]
        Tristate,
        [JsonStringEnumMemberName("booleanOrUndefined")]
        BooleanOrUndefined,
        [JsonStringEnumMemberName("idref")]
        Idref,
        [JsonStringEnumMemberName("idrefList")]
        IdrefList,
        [JsonStringEnumMemberName("integer")]
        Integer,
        [JsonStringEnumMemberName("node")]
        Node,
        [JsonStringEnumMemberName("nodeList")]
        NodeList,
        [JsonStringEnumMemberName("number")]
        Number,
        [JsonStringEnumMemberName("string")]
        String,
        [JsonStringEnumMemberName("computedString")]
        ComputedString,
        [JsonStringEnumMemberName("token")]
        Token,
        [JsonStringEnumMemberName("tokenList")]
        TokenList,
        [JsonStringEnumMemberName("domRelation")]
        DomRelation,
        [JsonStringEnumMemberName("role")]
        Role,
        [JsonStringEnumMemberName("internalRole")]
        InternalRole,
        [JsonStringEnumMemberName("valueUndefined")]
        ValueUndefined,
    }
}
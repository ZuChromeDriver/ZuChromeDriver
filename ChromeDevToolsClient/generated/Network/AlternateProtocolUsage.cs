namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// The reason why Chrome uses a specific transport protocol for HTTP semantics.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AlternateProtocolUsage
    {
        [JsonStringEnumMemberName("alternativeJobWonWithoutRace")]
        AlternativeJobWonWithoutRace,
        [JsonStringEnumMemberName("alternativeJobWonRace")]
        AlternativeJobWonRace,
        [JsonStringEnumMemberName("mainJobWonRace")]
        MainJobWonRace,
        [JsonStringEnumMemberName("mappingMissing")]
        MappingMissing,
        [JsonStringEnumMemberName("broken")]
        Broken,
        [JsonStringEnumMemberName("dnsAlpnH3JobWonWithoutRace")]
        DnsAlpnH3JobWonWithoutRace,
        [JsonStringEnumMemberName("dnsAlpnH3JobWonRace")]
        DnsAlpnH3JobWonRace,
        [JsonStringEnumMemberName("unspecifiedReason")]
        UnspecifiedReason,
    }
}
namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UnencodedDigestError
    {
        [JsonStringEnumMemberName("MalformedDictionary")]
        MalformedDictionary,
        [JsonStringEnumMemberName("UnknownAlgorithm")]
        UnknownAlgorithm,
        [JsonStringEnumMemberName("IncorrectDigestType")]
        IncorrectDigestType,
        [JsonStringEnumMemberName("IncorrectDigestLength")]
        IncorrectDigestLength,
    }
}
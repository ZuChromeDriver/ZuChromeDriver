namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Origin Trial(https://www.chromium.org/blink/origin-trials) support.
    /// Status for an Origin Trial token.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OriginTrialTokenStatus
    {
        [JsonStringEnumMemberName("Success")]
        Success,
        [JsonStringEnumMemberName("NotSupported")]
        NotSupported,
        [JsonStringEnumMemberName("Insecure")]
        Insecure,
        [JsonStringEnumMemberName("Expired")]
        Expired,
        [JsonStringEnumMemberName("WrongOrigin")]
        WrongOrigin,
        [JsonStringEnumMemberName("InvalidSignature")]
        InvalidSignature,
        [JsonStringEnumMemberName("Malformed")]
        Malformed,
        [JsonStringEnumMemberName("WrongVersion")]
        WrongVersion,
        [JsonStringEnumMemberName("FeatureDisabled")]
        FeatureDisabled,
        [JsonStringEnumMemberName("TokenDisabled")]
        TokenDisabled,
        [JsonStringEnumMemberName("FeatureDisabledForUser")]
        FeatureDisabledForUser,
        [JsonStringEnumMemberName("UnknownTrial")]
        UnknownTrial,
    }
}
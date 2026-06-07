namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Status for an Origin Trial.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OriginTrialStatus
    {
        [JsonStringEnumMemberName("Enabled")]
        Enabled,
        [JsonStringEnumMemberName("ValidTokenNotProvided")]
        ValidTokenNotProvided,
        [JsonStringEnumMemberName("OSNotSupported")]
        OSNotSupported,
        [JsonStringEnumMemberName("TrialNotAllowed")]
        TrialNotAllowed,
    }
}
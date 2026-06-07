namespace Zu.ChromeDevTools.FedCm
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// The URLs that each account has
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AccountUrlType
    {
        [JsonStringEnumMemberName("TermsOfService")]
        TermsOfService,
        [JsonStringEnumMemberName("PrivacyPolicy")]
        PrivacyPolicy,
    }
}
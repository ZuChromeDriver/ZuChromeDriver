namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Indicates whether the frame is a secure context and why it is the case.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SecureContextType
    {
        [JsonStringEnumMemberName("Secure")]
        Secure,
        [JsonStringEnumMemberName("SecureLocalhost")]
        SecureLocalhost,
        [JsonStringEnumMemberName("InsecureScheme")]
        InsecureScheme,
        [JsonStringEnumMemberName("InsecureAncestor")]
        InsecureAncestor,
    }
}
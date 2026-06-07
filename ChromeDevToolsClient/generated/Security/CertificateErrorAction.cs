namespace Zu.ChromeDevTools.Security
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// The action to take when a certificate error occurs. continue will continue processing the
    /// request and cancel will cancel the request.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CertificateErrorAction
    {
        [JsonStringEnumMemberName("continue")]
        Continue,
        [JsonStringEnumMemberName("cancel")]
        Cancel,
    }
}
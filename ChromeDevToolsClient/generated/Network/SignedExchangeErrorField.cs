namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Field type for a signed exchange related error.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SignedExchangeErrorField
    {
        [JsonStringEnumMemberName("signatureSig")]
        SignatureSig,
        [JsonStringEnumMemberName("signatureIntegrity")]
        SignatureIntegrity,
        [JsonStringEnumMemberName("signatureCertUrl")]
        SignatureCertUrl,
        [JsonStringEnumMemberName("signatureCertSha256")]
        SignatureCertSha256,
        [JsonStringEnumMemberName("signatureValidityUrl")]
        SignatureValidityUrl,
        [JsonStringEnumMemberName("signatureTimestamps")]
        SignatureTimestamps,
    }
}
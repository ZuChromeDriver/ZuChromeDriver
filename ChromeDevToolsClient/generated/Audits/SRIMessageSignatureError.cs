namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SRIMessageSignatureError
    {
        [JsonStringEnumMemberName("MissingSignatureHeader")]
        MissingSignatureHeader,
        [JsonStringEnumMemberName("MissingSignatureInputHeader")]
        MissingSignatureInputHeader,
        [JsonStringEnumMemberName("InvalidSignatureHeader")]
        InvalidSignatureHeader,
        [JsonStringEnumMemberName("InvalidSignatureInputHeader")]
        InvalidSignatureInputHeader,
        [JsonStringEnumMemberName("SignatureHeaderValueIsNotByteSequence")]
        SignatureHeaderValueIsNotByteSequence,
        [JsonStringEnumMemberName("SignatureHeaderValueIsParameterized")]
        SignatureHeaderValueIsParameterized,
        [JsonStringEnumMemberName("SignatureHeaderValueIsIncorrectLength")]
        SignatureHeaderValueIsIncorrectLength,
        [JsonStringEnumMemberName("SignatureInputHeaderMissingLabel")]
        SignatureInputHeaderMissingLabel,
        [JsonStringEnumMemberName("SignatureInputHeaderValueNotInnerList")]
        SignatureInputHeaderValueNotInnerList,
        [JsonStringEnumMemberName("SignatureInputHeaderValueMissingComponents")]
        SignatureInputHeaderValueMissingComponents,
        [JsonStringEnumMemberName("SignatureInputHeaderInvalidComponentType")]
        SignatureInputHeaderInvalidComponentType,
        [JsonStringEnumMemberName("SignatureInputHeaderInvalidComponentName")]
        SignatureInputHeaderInvalidComponentName,
        [JsonStringEnumMemberName("SignatureInputHeaderInvalidHeaderComponentParameter")]
        SignatureInputHeaderInvalidHeaderComponentParameter,
        [JsonStringEnumMemberName("SignatureInputHeaderInvalidDerivedComponentParameter")]
        SignatureInputHeaderInvalidDerivedComponentParameter,
        [JsonStringEnumMemberName("SignatureInputHeaderKeyIdLength")]
        SignatureInputHeaderKeyIdLength,
        [JsonStringEnumMemberName("SignatureInputHeaderInvalidParameter")]
        SignatureInputHeaderInvalidParameter,
        [JsonStringEnumMemberName("SignatureInputHeaderMissingRequiredParameters")]
        SignatureInputHeaderMissingRequiredParameters,
        [JsonStringEnumMemberName("ValidationFailedSignatureExpired")]
        ValidationFailedSignatureExpired,
        [JsonStringEnumMemberName("ValidationFailedInvalidLength")]
        ValidationFailedInvalidLength,
        [JsonStringEnumMemberName("ValidationFailedSignatureMismatch")]
        ValidationFailedSignatureMismatch,
        [JsonStringEnumMemberName("ValidationFailedIntegrityMismatch")]
        ValidationFailedIntegrityMismatch,
        [JsonStringEnumMemberName("SignatureBaseUnknownDerivedComponent")]
        SignatureBaseUnknownDerivedComponent,
        [JsonStringEnumMemberName("SignatureBaseMissingHeader")]
        SignatureBaseMissingHeader,
        [JsonStringEnumMemberName("SignatureBaseInvalidUnencodedDigest")]
        SignatureBaseInvalidUnencodedDigest,
        [JsonStringEnumMemberName("SignatureBaseUnsupportedComponent")]
        SignatureBaseUnsupportedComponent,
    }
}
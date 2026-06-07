namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SharedDictionaryError
    {
        [JsonStringEnumMemberName("UseErrorCrossOriginNoCorsRequest")]
        UseErrorCrossOriginNoCorsRequest,
        [JsonStringEnumMemberName("UseErrorDictionaryLoadFailure")]
        UseErrorDictionaryLoadFailure,
        [JsonStringEnumMemberName("UseErrorMatchingDictionaryNotUsed")]
        UseErrorMatchingDictionaryNotUsed,
        [JsonStringEnumMemberName("UseErrorUnexpectedContentDictionaryHeader")]
        UseErrorUnexpectedContentDictionaryHeader,
        [JsonStringEnumMemberName("WriteErrorCossOriginNoCorsRequest")]
        WriteErrorCossOriginNoCorsRequest,
        [JsonStringEnumMemberName("WriteErrorDisallowedBySettings")]
        WriteErrorDisallowedBySettings,
        [JsonStringEnumMemberName("WriteErrorExpiredResponse")]
        WriteErrorExpiredResponse,
        [JsonStringEnumMemberName("WriteErrorFeatureDisabled")]
        WriteErrorFeatureDisabled,
        [JsonStringEnumMemberName("WriteErrorInsufficientResources")]
        WriteErrorInsufficientResources,
        [JsonStringEnumMemberName("WriteErrorInvalidMatchField")]
        WriteErrorInvalidMatchField,
        [JsonStringEnumMemberName("WriteErrorInvalidStructuredHeader")]
        WriteErrorInvalidStructuredHeader,
        [JsonStringEnumMemberName("WriteErrorInvalidTTLField")]
        WriteErrorInvalidTTLField,
        [JsonStringEnumMemberName("WriteErrorNavigationRequest")]
        WriteErrorNavigationRequest,
        [JsonStringEnumMemberName("WriteErrorNoMatchField")]
        WriteErrorNoMatchField,
        [JsonStringEnumMemberName("WriteErrorNonIntegerTTLField")]
        WriteErrorNonIntegerTTLField,
        [JsonStringEnumMemberName("WriteErrorNonListMatchDestField")]
        WriteErrorNonListMatchDestField,
        [JsonStringEnumMemberName("WriteErrorNonSecureContext")]
        WriteErrorNonSecureContext,
        [JsonStringEnumMemberName("WriteErrorNonStringIdField")]
        WriteErrorNonStringIdField,
        [JsonStringEnumMemberName("WriteErrorNonStringInMatchDestList")]
        WriteErrorNonStringInMatchDestList,
        [JsonStringEnumMemberName("WriteErrorNonStringMatchField")]
        WriteErrorNonStringMatchField,
        [JsonStringEnumMemberName("WriteErrorNonTokenTypeField")]
        WriteErrorNonTokenTypeField,
        [JsonStringEnumMemberName("WriteErrorRequestAborted")]
        WriteErrorRequestAborted,
        [JsonStringEnumMemberName("WriteErrorShuttingDown")]
        WriteErrorShuttingDown,
        [JsonStringEnumMemberName("WriteErrorTooLongIdField")]
        WriteErrorTooLongIdField,
        [JsonStringEnumMemberName("WriteErrorUnsupportedType")]
        WriteErrorUnsupportedType,
    }
}
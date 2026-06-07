namespace Zu.ChromeDevTools.SmartCardEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Indicates the PC/SC error code.
    /// 
    /// This maps to:
    /// PC/SC Lite: https://pcsclite.apdu.fr/api/group__ErrorCodes.html
    /// Microsoft: https://learn.microsoft.com/en-us/windows/win32/secauthn/authentication-return-values
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ResultCode
    {
        [JsonStringEnumMemberName("success")]
        Success,
        [JsonStringEnumMemberName("removed-card")]
        RemovedCard,
        [JsonStringEnumMemberName("reset-card")]
        ResetCard,
        [JsonStringEnumMemberName("unpowered-card")]
        UnpoweredCard,
        [JsonStringEnumMemberName("unresponsive-card")]
        UnresponsiveCard,
        [JsonStringEnumMemberName("unsupported-card")]
        UnsupportedCard,
        [JsonStringEnumMemberName("reader-unavailable")]
        ReaderUnavailable,
        [JsonStringEnumMemberName("sharing-violation")]
        SharingViolation,
        [JsonStringEnumMemberName("not-transacted")]
        NotTransacted,
        [JsonStringEnumMemberName("no-smartcard")]
        NoSmartcard,
        [JsonStringEnumMemberName("proto-mismatch")]
        ProtoMismatch,
        [JsonStringEnumMemberName("system-cancelled")]
        SystemCancelled,
        [JsonStringEnumMemberName("not-ready")]
        NotReady,
        [JsonStringEnumMemberName("cancelled")]
        Cancelled,
        [JsonStringEnumMemberName("insufficient-buffer")]
        InsufficientBuffer,
        [JsonStringEnumMemberName("invalid-handle")]
        InvalidHandle,
        [JsonStringEnumMemberName("invalid-parameter")]
        InvalidParameter,
        [JsonStringEnumMemberName("invalid-value")]
        InvalidValue,
        [JsonStringEnumMemberName("no-memory")]
        NoMemory,
        [JsonStringEnumMemberName("timeout")]
        Timeout,
        [JsonStringEnumMemberName("unknown-reader")]
        UnknownReader,
        [JsonStringEnumMemberName("unsupported-feature")]
        UnsupportedFeature,
        [JsonStringEnumMemberName("no-readers-available")]
        NoReadersAvailable,
        [JsonStringEnumMemberName("service-stopped")]
        ServiceStopped,
        [JsonStringEnumMemberName("no-service")]
        NoService,
        [JsonStringEnumMemberName("comm-error")]
        CommError,
        [JsonStringEnumMemberName("internal-error")]
        InternalError,
        [JsonStringEnumMemberName("server-too-busy")]
        ServerTooBusy,
        [JsonStringEnumMemberName("unexpected")]
        Unexpected,
        [JsonStringEnumMemberName("shutdown")]
        Shutdown,
        [JsonStringEnumMemberName("unknown-card")]
        UnknownCard,
        [JsonStringEnumMemberName("unknown")]
        Unknown,
    }
}
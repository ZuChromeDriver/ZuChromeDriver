namespace Zu.ChromeDevTools.SmartCardEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when |SCardGetStatusChange| is called. Timeout is specified in milliseconds.
    /// 
    /// This maps to:
    /// PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#ga33247d5d1257d59e55647c3bb717db24
    /// Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardgetstatuschangea
    /// </summary>
    public sealed class GetStatusChangeRequestedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the requestId
        /// </summary>
        [JsonPropertyName("requestId")]
        public string RequestId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the contextId
        /// </summary>
        [JsonPropertyName("contextId")]
        public long ContextId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the readerStates
        /// </summary>
        [JsonPropertyName("readerStates")]
        public ReaderStateIn[] ReaderStates
        {
            get;
            set;
        }
        /// <summary>
        /// in milliseconds, if absent, it means "infinite"
        /// </summary>
        [JsonPropertyName("timeout")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Timeout
        {
            get;
            set;
        }
    }
}
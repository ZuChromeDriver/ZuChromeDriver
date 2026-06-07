namespace Zu.ChromeDevTools.SmartCardEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when |SCardCancel| is called.
    /// 
    /// This maps to:
    /// PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#gaacbbc0c6d6c0cbbeb4f4debf6fbeeee6
    /// Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardcancel
    /// </summary>
    public sealed class CancelRequestedEvent : IEvent
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
    }
}
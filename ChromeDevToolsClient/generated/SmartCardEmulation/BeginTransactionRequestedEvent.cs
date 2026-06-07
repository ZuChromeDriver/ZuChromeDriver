namespace Zu.ChromeDevTools.SmartCardEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when |SCardBeginTransaction| is called.
    /// 
    /// This maps to:
    /// PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#gaddb835dce01a0da1d6ca02d33ee7d861
    /// Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardbegintransaction
    /// </summary>
    public sealed class BeginTransactionRequestedEvent : IEvent
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
        /// Gets or sets the handle
        /// </summary>
        [JsonPropertyName("handle")]
        public long Handle
        {
            get;
            set;
        }
    }
}
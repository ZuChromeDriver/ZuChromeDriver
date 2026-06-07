namespace Zu.ChromeDevTools.SmartCardEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when |SCardEndTransaction| is called.
    /// 
    /// This maps to:
    /// PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#gae8742473b404363e5c587f570d7e2f3b
    /// Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardendtransaction
    /// </summary>
    public sealed class EndTransactionRequestedEvent : IEvent
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
        /// <summary>
        /// Gets or sets the disposition
        /// </summary>
        [JsonPropertyName("disposition")]
        public Disposition Disposition
        {
            get;
            set;
        }
    }
}
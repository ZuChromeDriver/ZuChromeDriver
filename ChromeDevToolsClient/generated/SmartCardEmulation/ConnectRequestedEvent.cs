namespace Zu.ChromeDevTools.SmartCardEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when |SCardConnect| is called.
    /// 
    /// This maps to:
    /// PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#ga4e515829752e0a8dbc4d630696a8d6a5
    /// Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardconnecta
    /// </summary>
    public sealed class ConnectRequestedEvent : IEvent
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
        /// Gets or sets the reader
        /// </summary>
        [JsonPropertyName("reader")]
        public string Reader
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the shareMode
        /// </summary>
        [JsonPropertyName("shareMode")]
        public ShareMode ShareMode
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the preferredProtocols
        /// </summary>
        [JsonPropertyName("preferredProtocols")]
        public ProtocolSet PreferredProtocols
        {
            get;
            set;
        }
    }
}
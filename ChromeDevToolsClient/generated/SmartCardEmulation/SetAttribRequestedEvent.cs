namespace Zu.ChromeDevTools.SmartCardEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when |SCardSetAttrib| is called.
    /// 
    /// This maps to:
    /// PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#ga060f0038a4ddfd5dd2b8fadf3c3a2e4f
    /// Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardsetattrib
    /// </summary>
    public sealed class SetAttribRequestedEvent : IEvent
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
        /// Gets or sets the attribId
        /// </summary>
        [JsonPropertyName("attribId")]
        public long AttribId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the data
        /// </summary>
        [JsonPropertyName("data")]
        public string Data
        {
            get;
            set;
        }
    }
}
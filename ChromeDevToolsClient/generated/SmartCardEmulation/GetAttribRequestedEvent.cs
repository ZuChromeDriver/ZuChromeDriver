namespace Zu.ChromeDevTools.SmartCardEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when |SCardGetAttrib| is called.
    /// 
    /// This maps to:
    /// PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#gaacfec51917255b7a25b94c5104961602
    /// Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardgetattrib
    /// </summary>
    public sealed class GetAttribRequestedEvent : IEvent
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
    }
}
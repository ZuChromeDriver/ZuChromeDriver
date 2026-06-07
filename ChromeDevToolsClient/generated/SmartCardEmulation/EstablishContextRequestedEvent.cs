namespace Zu.ChromeDevTools.SmartCardEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when |SCardEstablishContext| is called.
    /// 
    /// This maps to:
    /// PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#gaa1b8970169fd4883a6dc4a8f43f19b67
    /// Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardestablishcontext
    /// </summary>
    public sealed class EstablishContextRequestedEvent : IEvent
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
    }
}
namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// How a device bound session was used during a request.
    /// </summary>
    public sealed class DeviceBoundSessionWithUsage
    {
        /// <summary>
        /// The key for the session.
        ///</summary>
        [JsonPropertyName("sessionKey")]
        public DeviceBoundSessionKey SessionKey
        {
            get;
            set;
        }
        /// <summary>
        /// How the session was used (or not used).
        ///</summary>
        [JsonPropertyName("usage")]
        public string Usage
        {
            get;
            set;
        }
    }
}
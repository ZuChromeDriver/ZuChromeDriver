namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Unique identifier for a device bound session.
    /// </summary>
    public sealed class DeviceBoundSessionKey
    {
        /// <summary>
        /// The site the session is set up for.
        ///</summary>
        [JsonPropertyName("site")]
        public string Site
        {
            get;
            set;
        }
        /// <summary>
        /// The id of the session.
        ///</summary>
        [JsonPropertyName("id")]
        public string Id
        {
            get;
            set;
        }
    }
}
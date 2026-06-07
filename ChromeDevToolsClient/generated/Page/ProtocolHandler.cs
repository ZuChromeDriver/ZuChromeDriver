namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class ProtocolHandler
    {
        /// <summary>
        /// Gets or sets the protocol
        /// </summary>
        [JsonPropertyName("protocol")]
        public string Protocol
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the url
        /// </summary>
        [JsonPropertyName("url")]
        public string Url
        {
            get;
            set;
        }
    }
}
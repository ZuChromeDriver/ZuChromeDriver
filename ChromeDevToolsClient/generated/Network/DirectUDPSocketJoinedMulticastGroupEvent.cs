namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class DirectUDPSocketJoinedMulticastGroupEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        [JsonPropertyName("identifier")]
        public string Identifier
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the IPAddress
        /// </summary>
        [JsonPropertyName("IPAddress")]
        public string IPAddress
        {
            get;
            set;
        }
    }
}
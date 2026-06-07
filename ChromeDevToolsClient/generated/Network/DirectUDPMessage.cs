namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class DirectUDPMessage
    {
        /// <summary>
        /// Gets or sets the data
        /// </summary>
        [JsonPropertyName("data")]
        public string Data
        {
            get;
            set;
        }
        /// <summary>
        /// Null for connected mode.
        ///</summary>
        [JsonPropertyName("remoteAddr")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string RemoteAddr
        {
            get;
            set;
        }
        /// <summary>
        /// Null for connected mode.
        /// Expected to be unsigned integer.
        ///</summary>
        [JsonPropertyName("remotePort")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? RemotePort
        {
            get;
            set;
        }
    }
}
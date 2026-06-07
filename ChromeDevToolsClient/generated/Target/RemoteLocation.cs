namespace Zu.ChromeDevTools.Target
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class RemoteLocation
    {
        /// <summary>
        /// Gets or sets the host
        /// </summary>
        [JsonPropertyName("host")]
        public string Host
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the port
        /// </summary>
        [JsonPropertyName("port")]
        public long Port
        {
            get;
            set;
        }
    }
}
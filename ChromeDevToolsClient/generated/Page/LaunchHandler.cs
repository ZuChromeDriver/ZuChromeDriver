namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class LaunchHandler
    {
        /// <summary>
        /// Gets or sets the clientMode
        /// </summary>
        [JsonPropertyName("clientMode")]
        public string ClientMode
        {
            get;
            set;
        }
    }
}
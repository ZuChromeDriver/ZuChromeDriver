namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Used to specify User Agent Client Hints to emulate. See https://wicg.github.io/ua-client-hints
    /// </summary>
    public sealed class UserAgentBrandVersion
    {
        /// <summary>
        /// Gets or sets the brand
        /// </summary>
        [JsonPropertyName("brand")]
        public string Brand
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the version
        /// </summary>
        [JsonPropertyName("version")]
        public string Version
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// An options object that may be extended later to better support CORS,
    /// CORB and streaming.
    /// </summary>
    public sealed class LoadNetworkResourceOptions
    {
        /// <summary>
        /// Gets or sets the disableCache
        /// </summary>
        [JsonPropertyName("disableCache")]
        public bool DisableCache
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the includeCredentials
        /// </summary>
        [JsonPropertyName("includeCredentials")]
        public bool IncludeCredentials
        {
            get;
            set;
        }
    }
}
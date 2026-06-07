namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class BlockPattern
    {
        /// <summary>
        /// URL pattern to match. Patterns use the URLPattern constructor string syntax
        /// (https://urlpattern.spec.whatwg.org/) and must be absolute. Example: `*://*:*/*.css`.
        ///</summary>
        [JsonPropertyName("urlPattern")]
        public string UrlPattern
        {
            get;
            set;
        }
        /// <summary>
        /// Whether or not to block the pattern. If false, a matching request will not be blocked even if it matches a later
        /// `BlockPattern`.
        ///</summary>
        [JsonPropertyName("block")]
        public bool Block
        {
            get;
            set;
        }
    }
}
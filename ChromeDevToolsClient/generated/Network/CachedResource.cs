namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Information about the cached resource.
    /// </summary>
    public sealed class CachedResource
    {
        /// <summary>
        /// Resource URL. This is the url of the original network request.
        ///</summary>
        [JsonPropertyName("url")]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// Type of this resource.
        ///</summary>
        [JsonPropertyName("type")]
        public ResourceType Type
        {
            get;
            set;
        }
        /// <summary>
        /// Cached response data.
        ///</summary>
        [JsonPropertyName("response")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Response Response
        {
            get;
            set;
        }
        /// <summary>
        /// Cached response body size.
        ///</summary>
        [JsonPropertyName("bodySize")]
        public double BodySize
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// HTTP response data.
    /// </summary>
    public sealed class Response
    {
        /// <summary>
        /// Response URL. This URL can be different from CachedResource.url in case of redirect.
        ///</summary>
        [JsonPropertyName("url")]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// HTTP response status code.
        ///</summary>
        [JsonPropertyName("status")]
        public long Status
        {
            get;
            set;
        }
        /// <summary>
        /// HTTP response status text.
        ///</summary>
        [JsonPropertyName("statusText")]
        public string StatusText
        {
            get;
            set;
        }
        /// <summary>
        /// HTTP response headers.
        ///</summary>
        [JsonPropertyName("headers")]
        public Headers Headers
        {
            get;
            set;
        }
        /// <summary>
        /// HTTP response headers text. This has been replaced by the headers in Network.responseReceivedExtraInfo.
        ///</summary>
        [JsonPropertyName("headersText")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string HeadersText
        {
            get;
            set;
        }
        /// <summary>
        /// Resource mimeType as determined by the browser.
        ///</summary>
        [JsonPropertyName("mimeType")]
        public string MimeType
        {
            get;
            set;
        }
        /// <summary>
        /// Resource charset as determined by the browser (if applicable).
        ///</summary>
        [JsonPropertyName("charset")]
        public string Charset
        {
            get;
            set;
        }
        /// <summary>
        /// Refined HTTP request headers that were actually transmitted over the network.
        ///</summary>
        [JsonPropertyName("requestHeaders")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Headers RequestHeaders
        {
            get;
            set;
        }
        /// <summary>
        /// HTTP request headers text. This has been replaced by the headers in Network.requestWillBeSentExtraInfo.
        ///</summary>
        [JsonPropertyName("requestHeadersText")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string RequestHeadersText
        {
            get;
            set;
        }
        /// <summary>
        /// Specifies whether physical connection was actually reused for this request.
        ///</summary>
        [JsonPropertyName("connectionReused")]
        public bool ConnectionReused
        {
            get;
            set;
        }
        /// <summary>
        /// Physical connection id that was actually used for this request.
        ///</summary>
        [JsonPropertyName("connectionId")]
        public double ConnectionId
        {
            get;
            set;
        }
        /// <summary>
        /// Remote IP address.
        ///</summary>
        [JsonPropertyName("remoteIPAddress")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string RemoteIPAddress
        {
            get;
            set;
        }
        /// <summary>
        /// Remote port.
        ///</summary>
        [JsonPropertyName("remotePort")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? RemotePort
        {
            get;
            set;
        }
        /// <summary>
        /// Specifies that the request was served from the disk cache.
        ///</summary>
        [JsonPropertyName("fromDiskCache")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? FromDiskCache
        {
            get;
            set;
        }
        /// <summary>
        /// Specifies that the request was served from the ServiceWorker.
        ///</summary>
        [JsonPropertyName("fromServiceWorker")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? FromServiceWorker
        {
            get;
            set;
        }
        /// <summary>
        /// Specifies that the request was served from the prefetch cache.
        ///</summary>
        [JsonPropertyName("fromPrefetchCache")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? FromPrefetchCache
        {
            get;
            set;
        }
        /// <summary>
        /// Specifies that the request was served from the prefetch cache.
        ///</summary>
        [JsonPropertyName("fromEarlyHints")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? FromEarlyHints
        {
            get;
            set;
        }
        /// <summary>
        /// Information about how ServiceWorker Static Router API was used. If this
        /// field is set with `matchedSourceType` field, a matching rule is found.
        /// If this field is set without `matchedSource`, no matching rule is found.
        /// Otherwise, the API is not used.
        ///</summary>
        [JsonPropertyName("serviceWorkerRouterInfo")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ServiceWorkerRouterInfo ServiceWorkerRouterInfo
        {
            get;
            set;
        }
        /// <summary>
        /// Total number of bytes received for this request so far.
        ///</summary>
        [JsonPropertyName("encodedDataLength")]
        public double EncodedDataLength
        {
            get;
            set;
        }
        /// <summary>
        /// Timing information for the given request.
        ///</summary>
        [JsonPropertyName("timing")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ResourceTiming Timing
        {
            get;
            set;
        }
        /// <summary>
        /// Response source of response from ServiceWorker.
        ///</summary>
        [JsonPropertyName("serviceWorkerResponseSource")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ServiceWorkerResponseSource? ServiceWorkerResponseSource
        {
            get;
            set;
        }
        /// <summary>
        /// The time at which the returned response was generated.
        ///</summary>
        [JsonPropertyName("responseTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? ResponseTime
        {
            get;
            set;
        }
        /// <summary>
        /// Cache Storage Cache Name.
        ///</summary>
        [JsonPropertyName("cacheStorageCacheName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string CacheStorageCacheName
        {
            get;
            set;
        }
        /// <summary>
        /// Protocol used to fetch this request.
        ///</summary>
        [JsonPropertyName("protocol")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Protocol
        {
            get;
            set;
        }
        /// <summary>
        /// The reason why Chrome uses a specific transport protocol for HTTP semantics.
        ///</summary>
        [JsonPropertyName("alternateProtocolUsage")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public AlternateProtocolUsage? AlternateProtocolUsage
        {
            get;
            set;
        }
        /// <summary>
        /// Security state of the request resource.
        ///</summary>
        [JsonPropertyName("securityState")]
        public Security.SecurityState SecurityState
        {
            get;
            set;
        }
        /// <summary>
        /// Security details for the request.
        ///</summary>
        [JsonPropertyName("securityDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public SecurityDetails SecurityDetails
        {
            get;
            set;
        }
    }
}
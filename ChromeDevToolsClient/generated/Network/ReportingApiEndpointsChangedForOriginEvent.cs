namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class ReportingApiEndpointsChangedForOriginEvent : IEvent
    {
        /// <summary>
        /// Origin of the document(s) which configured the endpoints.
        /// </summary>
        [JsonPropertyName("origin")]
        public string Origin
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the endpoints
        /// </summary>
        [JsonPropertyName("endpoints")]
        public ReportingApiEndpoint[] Endpoints
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class ReportingApiEndpoint
    {
        /// <summary>
        /// The URL of the endpoint to which reports may be delivered.
        ///</summary>
        [JsonPropertyName("url")]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// Name of the endpoint group.
        ///</summary>
        [JsonPropertyName("groupName")]
        public string GroupName
        {
            get;
            set;
        }
    }
}
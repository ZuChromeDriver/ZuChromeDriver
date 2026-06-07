namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Session event details specific to creation.
    /// </summary>
    public sealed class CreationEventDetails
    {
        /// <summary>
        /// The result of the fetch attempt.
        ///</summary>
        [JsonPropertyName("fetchResult")]
        public DeviceBoundSessionFetchResult FetchResult
        {
            get;
            set;
        }
        /// <summary>
        /// The session if there was a newly created session. This is populated for
        /// all successful creation events.
        ///</summary>
        [JsonPropertyName("newSession")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DeviceBoundSession NewSession
        {
            get;
            set;
        }
        /// <summary>
        /// Details about a failed device bound session network request if there was
        /// one.
        ///</summary>
        [JsonPropertyName("failedRequest")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DeviceBoundSessionFailedRequest FailedRequest
        {
            get;
            set;
        }
    }
}
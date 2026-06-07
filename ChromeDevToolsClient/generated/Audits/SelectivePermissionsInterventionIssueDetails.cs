namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// The issue warns about blocked calls to privacy sensitive APIs via the
    /// Selective Permissions Intervention.
    /// </summary>
    public sealed class SelectivePermissionsInterventionIssueDetails
    {
        /// <summary>
        /// Which API was intervened on.
        ///</summary>
        [JsonPropertyName("apiName")]
        public string ApiName
        {
            get;
            set;
        }
        /// <summary>
        /// Why the ad script using the API is considered an ad.
        ///</summary>
        [JsonPropertyName("adAncestry")]
        public Network.AdAncestry AdAncestry
        {
            get;
            set;
        }
        /// <summary>
        /// The stack trace at the time of the intervention.
        ///</summary>
        [JsonPropertyName("stackTrace")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Runtime.StackTrace StackTrace
        {
            get;
            set;
        }
    }
}
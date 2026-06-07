namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// This issue warns when a referenced stylesheet couldn't be loaded.
    /// </summary>
    public sealed class StylesheetLoadingIssueDetails
    {
        /// <summary>
        /// Source code position that referenced the failing stylesheet.
        ///</summary>
        [JsonPropertyName("sourceCodeLocation")]
        public SourceCodeLocation SourceCodeLocation
        {
            get;
            set;
        }
        /// <summary>
        /// Reason why the stylesheet couldn't be loaded.
        ///</summary>
        [JsonPropertyName("styleSheetLoadingIssueReason")]
        public StyleSheetLoadingIssueReason StyleSheetLoadingIssueReason
        {
            get;
            set;
        }
        /// <summary>
        /// Contains additional info when the failure was due to a request.
        ///</summary>
        [JsonPropertyName("failedRequestInfo")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public FailedRequestInfo FailedRequestInfo
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Get the annotated page content for the main frame.
    /// This is an experimental command that is subject to change.
    /// </summary>
    public sealed class GetAnnotatedPageContentCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.getAnnotatedPageContent";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Whether to include actionable information. Defaults to true.
        /// </summary>
        [JsonPropertyName("includeActionableInformation")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? IncludeActionableInformation
        {
            get;
            set;
        }
    }

    public sealed class GetAnnotatedPageContentCommandResponse : ICommandResponse<GetAnnotatedPageContentCommand>
    {
        /// <summary>
        /// The annotated page content as a base64 encoded protobuf.
        /// The format is defined by the `AnnotatedPageContent` message in
        /// components/optimization_guide/proto/features/common_quality_data.proto (Encoded as a base64 string when passed over JSON)
        ///</summary>
        [JsonPropertyName("content")]
        public string Content
        {
            get;
            set;
        }
    }
}
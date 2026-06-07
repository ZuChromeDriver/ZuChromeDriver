namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Sets given markup as the document's HTML.
    /// </summary>
    public sealed class SetDocumentContentCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.setDocumentContent";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Frame id to set HTML for.
        /// </summary>
        [JsonPropertyName("frameId")]
        public string FrameId
        {
            get;
            set;
        }
        /// <summary>
        /// HTML content to set.
        /// </summary>
        [JsonPropertyName("html")]
        public string Html
        {
            get;
            set;
        }
    }

    public sealed class SetDocumentContentCommandResponse : ICommandResponse<SetDocumentContentCommand>
    {
    }
}
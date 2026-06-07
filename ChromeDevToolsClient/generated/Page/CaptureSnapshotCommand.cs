namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns a snapshot of the page as a string. For MHTML format, the serialization includes
    /// iframes, shadow DOM, external resources, and element-inline styles.
    /// </summary>
    public sealed class CaptureSnapshotCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.captureSnapshot";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Format (defaults to mhtml).
        /// </summary>
        [JsonPropertyName("format")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Format
        {
            get;
            set;
        }
    }

    public sealed class CaptureSnapshotCommandResponse : ICommandResponse<CaptureSnapshotCommand>
    {
        /// <summary>
        /// Serialized page data.
        ///</summary>
        [JsonPropertyName("data")]
        public string Data
        {
            get;
            set;
        }
    }
}
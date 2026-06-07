namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Emitted only when `page.interceptFileChooser` is enabled.
    /// </summary>
    public sealed class FileChooserOpenedEvent : IEvent
    {
        /// <summary>
        /// Id of the frame containing input node.
        /// </summary>
        [JsonPropertyName("frameId")]
        public string FrameId
        {
            get;
            set;
        }
        /// <summary>
        /// Input mode.
        /// </summary>
        [JsonPropertyName("mode")]
        public string Mode
        {
            get;
            set;
        }
        /// <summary>
        /// Input node id. Only present for file choosers opened via an `<input type="file">` element.
        /// </summary>
        [JsonPropertyName("backendNodeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? BackendNodeId
        {
            get;
            set;
        }
    }
}
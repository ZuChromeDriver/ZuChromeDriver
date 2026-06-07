namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when a JavaScript initiated dialog (alert, confirm, prompt, or onbeforeunload) has been
    /// closed.
    /// </summary>
    public sealed class JavascriptDialogClosedEvent : IEvent
    {
        /// <summary>
        /// Frame id.
        /// </summary>
        [JsonPropertyName("frameId")]
        public string FrameId
        {
            get;
            set;
        }
        /// <summary>
        /// Whether dialog was confirmed.
        /// </summary>
        [JsonPropertyName("result")]
        public bool Result
        {
            get;
            set;
        }
        /// <summary>
        /// User input in case of prompt.
        /// </summary>
        [JsonPropertyName("userInput")]
        public string UserInput
        {
            get;
            set;
        }
    }
}
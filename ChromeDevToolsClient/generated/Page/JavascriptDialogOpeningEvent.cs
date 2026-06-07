namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when a JavaScript initiated dialog (alert, confirm, prompt, or onbeforeunload) is about to
    /// open.
    /// </summary>
    public sealed class JavascriptDialogOpeningEvent : IEvent
    {
        /// <summary>
        /// Frame url.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url
        {
            get;
            set;
        }
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
        /// Message that will be displayed by the dialog.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message
        {
            get;
            set;
        }
        /// <summary>
        /// Dialog type.
        /// </summary>
        [JsonPropertyName("type")]
        public DialogType Type
        {
            get;
            set;
        }
        /// <summary>
        /// True iff browser is capable showing or acting on the given dialog. When browser has no
        /// dialog handler for given target, calling alert while Page domain is engaged will stall
        /// the page execution. Execution can be resumed via calling Page.handleJavaScriptDialog.
        /// </summary>
        [JsonPropertyName("hasBrowserHandler")]
        public bool HasBrowserHandler
        {
            get;
            set;
        }
        /// <summary>
        /// Default dialog prompt.
        /// </summary>
        [JsonPropertyName("defaultPrompt")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string DefaultPrompt
        {
            get;
            set;
        }
    }
}
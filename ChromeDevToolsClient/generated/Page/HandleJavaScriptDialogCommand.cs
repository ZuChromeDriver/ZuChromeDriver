namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Accepts or dismisses a JavaScript initiated dialog (alert, confirm, prompt, or onbeforeunload).
    /// </summary>
    public sealed class HandleJavaScriptDialogCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.handleJavaScriptDialog";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Whether to accept or dismiss the dialog.
        /// </summary>
        [JsonPropertyName("accept")]
        public bool Accept
        {
            get;
            set;
        }
        /// <summary>
        /// The text to enter into the dialog prompt before accepting. Used only if this is a prompt
        /// dialog.
        /// </summary>
        [JsonPropertyName("promptText")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string PromptText
        {
            get;
            set;
        }
    }

    public sealed class HandleJavaScriptDialogCommandResponse : ICommandResponse<HandleJavaScriptDialogCommand>
    {
    }
}
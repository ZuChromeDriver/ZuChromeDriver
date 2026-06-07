namespace Zu.ChromeDevTools.Input
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// This method sets the current candidate text for IME.
    /// Use imeCommitComposition to commit the final text.
    /// Use imeSetComposition with empty string as text to cancel composition.
    /// </summary>
    public sealed class ImeSetCompositionCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Input.imeSetComposition";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// The text to insert
        /// </summary>
        [JsonPropertyName("text")]
        public string Text
        {
            get;
            set;
        }
        /// <summary>
        /// selection start
        /// </summary>
        [JsonPropertyName("selectionStart")]
        public long SelectionStart
        {
            get;
            set;
        }
        /// <summary>
        /// selection end
        /// </summary>
        [JsonPropertyName("selectionEnd")]
        public long SelectionEnd
        {
            get;
            set;
        }
        /// <summary>
        /// replacement start
        /// </summary>
        [JsonPropertyName("replacementStart")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? ReplacementStart
        {
            get;
            set;
        }
        /// <summary>
        /// replacement end
        /// </summary>
        [JsonPropertyName("replacementEnd")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? ReplacementEnd
        {
            get;
            set;
        }
    }

    public sealed class ImeSetCompositionCommandResponse : ICommandResponse<ImeSetCompositionCommand>
    {
    }
}
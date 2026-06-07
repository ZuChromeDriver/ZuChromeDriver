namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Modifies the keyframe rule key text.
    /// </summary>
    public sealed class SetKeyframeKeyCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "CSS.setKeyframeKey";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the styleSheetId
        /// </summary>
        [JsonPropertyName("styleSheetId")]
        public string StyleSheetId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the range
        /// </summary>
        [JsonPropertyName("range")]
        public SourceRange Range
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the keyText
        /// </summary>
        [JsonPropertyName("keyText")]
        public string KeyText
        {
            get;
            set;
        }
    }

    public sealed class SetKeyframeKeyCommandResponse : ICommandResponse<SetKeyframeKeyCommand>
    {
        /// <summary>
        /// The resulting key text after modification.
        ///</summary>
        [JsonPropertyName("keyText")]
        public Value KeyText
        {
            get;
            set;
        }
    }
}
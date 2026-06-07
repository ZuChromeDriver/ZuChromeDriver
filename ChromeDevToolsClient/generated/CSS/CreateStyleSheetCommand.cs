namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Creates a new special "via-inspector" stylesheet in the frame with given `frameId`.
    /// </summary>
    public sealed class CreateStyleSheetCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "CSS.createStyleSheet";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Identifier of the frame where "via-inspector" stylesheet should be created.
        /// </summary>
        [JsonPropertyName("frameId")]
        public string FrameId
        {
            get;
            set;
        }
        /// <summary>
        /// If true, creates a new stylesheet for every call. If false,
        /// returns a stylesheet previously created by a call with force=false
        /// for the frame's document if it exists or creates a new stylesheet
        /// (default: false).
        /// </summary>
        [JsonPropertyName("force")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Force
        {
            get;
            set;
        }
    }

    public sealed class CreateStyleSheetCommandResponse : ICommandResponse<CreateStyleSheetCommand>
    {
        /// <summary>
        /// Identifier of the created "via-inspector" stylesheet.
        ///</summary>
        [JsonPropertyName("styleSheetId")]
        public string StyleSheetId
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Highlights given rectangle. Coordinates are absolute with respect to the main frame viewport.
    /// Issue: the method does not handle device pixel ratio (DPR) correctly.
    /// The coordinates currently have to be adjusted by the client
    /// if DPR is not 1 (see crbug.com/437807128).
    /// </summary>
    public sealed class HighlightRectCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Overlay.highlightRect";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// X coordinate
        /// </summary>
        [JsonPropertyName("x")]
        public long X
        {
            get;
            set;
        }
        /// <summary>
        /// Y coordinate
        /// </summary>
        [JsonPropertyName("y")]
        public long Y
        {
            get;
            set;
        }
        /// <summary>
        /// Rectangle width
        /// </summary>
        [JsonPropertyName("width")]
        public long Width
        {
            get;
            set;
        }
        /// <summary>
        /// Rectangle height
        /// </summary>
        [JsonPropertyName("height")]
        public long Height
        {
            get;
            set;
        }
        /// <summary>
        /// The highlight fill color (default: transparent).
        /// </summary>
        [JsonPropertyName("color")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DOM.RGBA Color
        {
            get;
            set;
        }
        /// <summary>
        /// The highlight outline color (default: transparent).
        /// </summary>
        [JsonPropertyName("outlineColor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DOM.RGBA OutlineColor
        {
            get;
            set;
        }
    }

    public sealed class HighlightRectCommandResponse : ICommandResponse<HighlightRectCommand>
    {
    }
}
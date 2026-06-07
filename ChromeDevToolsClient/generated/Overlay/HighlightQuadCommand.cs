namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Highlights given quad. Coordinates are absolute with respect to the main frame viewport.
    /// </summary>
    public sealed class HighlightQuadCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Overlay.highlightQuad";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Quad to highlight
        /// </summary>
        [JsonPropertyName("quad")]
        public double[] Quad
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

    public sealed class HighlightQuadCommandResponse : ICommandResponse<HighlightQuadCommand>
    {
    }
}
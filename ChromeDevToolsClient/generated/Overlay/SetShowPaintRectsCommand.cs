namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Requests that backend shows paint rectangles
    /// </summary>
    public sealed class SetShowPaintRectsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Overlay.setShowPaintRects";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// True for showing paint rectangles
        /// </summary>
        [JsonPropertyName("result")]
        public bool Result
        {
            get;
            set;
        }
    }

    public sealed class SetShowPaintRectsCommandResponse : ICommandResponse<SetShowPaintRectsCommand>
    {
    }
}
namespace Zu.ChromeDevTools.Browser
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Set size of the browser contents resizing browser window as necessary.
    /// </summary>
    public sealed class SetContentsSizeCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Browser.setContentsSize";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Browser window id.
        /// </summary>
        [JsonPropertyName("windowId")]
        public long WindowId
        {
            get;
            set;
        }
        /// <summary>
        /// The window contents width in DIP. Assumes current width if omitted.
        /// Must be specified if 'height' is omitted.
        /// </summary>
        [JsonPropertyName("width")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Width
        {
            get;
            set;
        }
        /// <summary>
        /// The window contents height in DIP. Assumes current height if omitted.
        /// Must be specified if 'width' is omitted.
        /// </summary>
        [JsonPropertyName("height")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Height
        {
            get;
            set;
        }
    }

    public sealed class SetContentsSizeCommandResponse : ICommandResponse<SetContentsSizeCommand>
    {
    }
}
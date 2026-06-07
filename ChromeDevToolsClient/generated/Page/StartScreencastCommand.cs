namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Starts sending each frame using the `screencastFrame` event.
    /// </summary>
    public sealed class StartScreencastCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.startScreencast";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Image compression format.
        /// </summary>
        [JsonPropertyName("format")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Format
        {
            get;
            set;
        }
        /// <summary>
        /// Compression quality from range [0..100].
        /// </summary>
        [JsonPropertyName("quality")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Quality
        {
            get;
            set;
        }
        /// <summary>
        /// Maximum screenshot width.
        /// </summary>
        [JsonPropertyName("maxWidth")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? MaxWidth
        {
            get;
            set;
        }
        /// <summary>
        /// Maximum screenshot height.
        /// </summary>
        [JsonPropertyName("maxHeight")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? MaxHeight
        {
            get;
            set;
        }
        /// <summary>
        /// Send every n-th frame.
        /// </summary>
        [JsonPropertyName("everyNthFrame")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? EveryNthFrame
        {
            get;
            set;
        }
    }

    public sealed class StartScreencastCommandResponse : ICommandResponse<StartScreencastCommand>
    {
    }
}
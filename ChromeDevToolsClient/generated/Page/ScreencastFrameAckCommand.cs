namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Acknowledges that a screencast frame has been received by the frontend.
    /// </summary>
    public sealed class ScreencastFrameAckCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.screencastFrameAck";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Frame number.
        /// </summary>
        [JsonPropertyName("sessionId")]
        public long SessionId
        {
            get;
            set;
        }
    }

    public sealed class ScreencastFrameAckCommandResponse : ICommandResponse<ScreencastFrameAckCommand>
    {
    }
}
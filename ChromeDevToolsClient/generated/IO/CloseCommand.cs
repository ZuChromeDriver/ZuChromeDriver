namespace Zu.ChromeDevTools.IO
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Close the stream, discard any temporary backing storage.
    /// </summary>
    public sealed class CloseCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "IO.close";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Handle of the stream to close.
        /// </summary>
        [JsonPropertyName("handle")]
        public string Handle
        {
            get;
            set;
        }
    }

    public sealed class CloseCommandResponse : ICommandResponse<CloseCommand>
    {
    }
}
namespace Zu.ChromeDevTools.Runtime
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class SetMaxCallStackSizeToCaptureCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Runtime.setMaxCallStackSizeToCapture";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the size
        /// </summary>
        [JsonPropertyName("size")]
        public long Size
        {
            get;
            set;
        }
    }

    public sealed class SetMaxCallStackSizeToCaptureCommandResponse : ICommandResponse<SetMaxCallStackSizeToCaptureCommand>
    {
    }
}
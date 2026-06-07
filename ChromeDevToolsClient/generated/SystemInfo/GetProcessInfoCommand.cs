namespace Zu.ChromeDevTools.SystemInfo
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns information about all running processes.
    /// </summary>
    public sealed class GetProcessInfoCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "SystemInfo.getProcessInfo";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class GetProcessInfoCommandResponse : ICommandResponse<GetProcessInfoCommand>
    {
        /// <summary>
        /// An array of process info blocks.
        ///</summary>
        [JsonPropertyName("processInfo")]
        public ProcessInfo[] ProcessInfo
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.Log
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// start violation reporting.
    /// </summary>
    public sealed class StartViolationsReportCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Log.startViolationsReport";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Configuration for violations.
        /// </summary>
        [JsonPropertyName("config")]
        public ViolationSetting[] Config
        {
            get;
            set;
        }
    }

    public sealed class StartViolationsReportCommandResponse : ICommandResponse<StartViolationsReportCommand>
    {
    }
}
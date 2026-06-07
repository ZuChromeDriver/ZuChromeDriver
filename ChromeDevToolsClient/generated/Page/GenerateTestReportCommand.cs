namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Generates a report for testing.
    /// </summary>
    public sealed class GenerateTestReportCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.generateTestReport";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Message to be displayed in the report.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message
        {
            get;
            set;
        }
        /// <summary>
        /// Specifies the endpoint group to deliver the report to.
        /// </summary>
        [JsonPropertyName("group")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Group
        {
            get;
            set;
        }
    }

    public sealed class GenerateTestReportCommandResponse : ICommandResponse<GenerateTestReportCommand>
    {
    }
}
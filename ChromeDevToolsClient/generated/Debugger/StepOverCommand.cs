namespace Zu.ChromeDevTools.Debugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Steps over the statement.
    /// </summary>
    public sealed class StepOverCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Debugger.stepOver";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// The skipList specifies location ranges that should be skipped on step over.
        /// </summary>
        [JsonPropertyName("skipList")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public LocationRange[] SkipList
        {
            get;
            set;
        }
    }

    public sealed class StepOverCommandResponse : ICommandResponse<StepOverCommand>
    {
    }
}
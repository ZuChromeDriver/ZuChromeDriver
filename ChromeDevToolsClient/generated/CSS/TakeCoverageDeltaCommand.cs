namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Obtain list of rules that became used since last call to this method (or since start of coverage
    /// instrumentation).
    /// </summary>
    public sealed class TakeCoverageDeltaCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "CSS.takeCoverageDelta";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class TakeCoverageDeltaCommandResponse : ICommandResponse<TakeCoverageDeltaCommand>
    {
        /// <summary>
        /// Gets or sets the coverage
        /// </summary>
        [JsonPropertyName("coverage")]
        public RuleUsage[] Coverage
        {
            get;
            set;
        }
        /// <summary>
        /// Monotonically increasing time, in seconds.
        ///</summary>
        [JsonPropertyName("timestamp")]
        public double Timestamp
        {
            get;
            set;
        }
    }
}
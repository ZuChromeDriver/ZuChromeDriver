namespace Zu.ChromeDevTools.Profiler
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Collect coverage data for the current isolate, and resets execution counters. Precise code
    /// coverage needs to have started.
    /// </summary>
    public sealed class TakePreciseCoverageCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Profiler.takePreciseCoverage";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class TakePreciseCoverageCommandResponse : ICommandResponse<TakePreciseCoverageCommand>
    {
        /// <summary>
        /// Coverage data for the current isolate.
        ///</summary>
        [JsonPropertyName("result")]
        public ScriptCoverage[] Result
        {
            get;
            set;
        }
        /// <summary>
        /// Monotonically increasing time (in seconds) when the coverage update was taken in the backend.
        ///</summary>
        [JsonPropertyName("timestamp")]
        public double Timestamp
        {
            get;
            set;
        }
    }
}
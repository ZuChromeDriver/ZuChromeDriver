namespace Zu.ChromeDevTools.Performance
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Retrieve current values of run-time metrics.
    /// </summary>
    public sealed class GetMetricsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Performance.getMetrics";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class GetMetricsCommandResponse : ICommandResponse<GetMetricsCommand>
    {
        /// <summary>
        /// Current values for run-time metrics.
        ///</summary>
        [JsonPropertyName("metrics")]
        public Metric[] Metrics
        {
            get;
            set;
        }
    }
}
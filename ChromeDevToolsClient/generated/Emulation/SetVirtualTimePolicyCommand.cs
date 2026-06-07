namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Turns on virtual time for all frames (replacing real-time with a synthetic time source) and sets
    /// the current virtual time policy.  Note this supersedes any previous time budget.
    /// </summary>
    public sealed class SetVirtualTimePolicyCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Emulation.setVirtualTimePolicy";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the policy
        /// </summary>
        [JsonPropertyName("policy")]
        public VirtualTimePolicy Policy
        {
            get;
            set;
        }
        /// <summary>
        /// If set, after this many virtual milliseconds have elapsed virtual time will be paused and a
        /// virtualTimeBudgetExpired event is sent.
        /// </summary>
        [JsonPropertyName("budget")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? Budget
        {
            get;
            set;
        }
        /// <summary>
        /// If set this specifies the maximum number of tasks that can be run before virtual is forced
        /// forwards to prevent deadlock.
        /// </summary>
        [JsonPropertyName("maxVirtualTimeTaskStarvationCount")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? MaxVirtualTimeTaskStarvationCount
        {
            get;
            set;
        }
        /// <summary>
        /// If set, base::Time::Now will be overridden to initially return this value.
        /// </summary>
        [JsonPropertyName("initialVirtualTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? InitialVirtualTime
        {
            get;
            set;
        }
    }

    public sealed class SetVirtualTimePolicyCommandResponse : ICommandResponse<SetVirtualTimePolicyCommand>
    {
        /// <summary>
        /// Absolute timestamp at which virtual time was first enabled (up time in milliseconds).
        ///</summary>
        [JsonPropertyName("virtualTimeTicksBase")]
        public double VirtualTimeTicksBase
        {
            get;
            set;
        }
    }
}
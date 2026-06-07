namespace Zu.ChromeDevTools.HeapProfiler
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class StartSamplingCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "HeapProfiler.startSampling";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Average sample interval in bytes. Poisson distribution is used for the intervals. The
        /// default value is 32768 bytes.
        /// </summary>
        [JsonPropertyName("samplingInterval")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? SamplingInterval
        {
            get;
            set;
        }
        /// <summary>
        /// Maximum stack depth. The default value is 128.
        /// </summary>
        [JsonPropertyName("stackDepth")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? StackDepth
        {
            get;
            set;
        }
        /// <summary>
        /// By default, the sampling heap profiler reports only objects which are
        /// still alive when the profile is returned via getSamplingProfile or
        /// stopSampling, which is useful for determining what functions contribute
        /// the most to steady-state memory usage. This flag instructs the sampling
        /// heap profiler to also include information about objects discarded by
        /// major GC, which will show which functions cause large temporary memory
        /// usage or long GC pauses.
        /// </summary>
        [JsonPropertyName("includeObjectsCollectedByMajorGC")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? IncludeObjectsCollectedByMajorGC
        {
            get;
            set;
        }
        /// <summary>
        /// By default, the sampling heap profiler reports only objects which are
        /// still alive when the profile is returned via getSamplingProfile or
        /// stopSampling, which is useful for determining what functions contribute
        /// the most to steady-state memory usage. This flag instructs the sampling
        /// heap profiler to also include information about objects discarded by
        /// minor GC, which is useful when tuning a latency-sensitive application
        /// for minimal GC activity.
        /// </summary>
        [JsonPropertyName("includeObjectsCollectedByMinorGC")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? IncludeObjectsCollectedByMinorGC
        {
            get;
            set;
        }
    }

    public sealed class StartSamplingCommandResponse : ICommandResponse<StartSamplingCommand>
    {
    }
}
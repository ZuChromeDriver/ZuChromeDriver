namespace Zu.ChromeDevTools.Tracing
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class TraceConfig
    {
        /// <summary>
        /// Controls how the trace buffer stores data. The default is `recordUntilFull`.
        ///</summary>
        [JsonPropertyName("recordMode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string RecordMode
        {
            get;
            set;
        }
        /// <summary>
        /// Size of the trace buffer in kilobytes. If not specified or zero is passed, a default value
        /// of 200 MB would be used.
        ///</summary>
        [JsonPropertyName("traceBufferSizeInKb")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? TraceBufferSizeInKb
        {
            get;
            set;
        }
        /// <summary>
        /// Turns on JavaScript stack sampling.
        ///</summary>
        [JsonPropertyName("enableSampling")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? EnableSampling
        {
            get;
            set;
        }
        /// <summary>
        /// Turns on system tracing.
        ///</summary>
        [JsonPropertyName("enableSystrace")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? EnableSystrace
        {
            get;
            set;
        }
        /// <summary>
        /// Turns on argument filter.
        ///</summary>
        [JsonPropertyName("enableArgumentFilter")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? EnableArgumentFilter
        {
            get;
            set;
        }
        /// <summary>
        /// Included category filters.
        ///</summary>
        [JsonPropertyName("includedCategories")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string[] IncludedCategories
        {
            get;
            set;
        }
        /// <summary>
        /// Excluded category filters.
        ///</summary>
        [JsonPropertyName("excludedCategories")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string[] ExcludedCategories
        {
            get;
            set;
        }
        /// <summary>
        /// Configuration to synthesize the delays in tracing.
        ///</summary>
        [JsonPropertyName("syntheticDelays")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string[] SyntheticDelays
        {
            get;
            set;
        }
        /// <summary>
        /// Configuration for memory dump triggers. Used only when "memory-infra" category is enabled.
        ///</summary>
        [JsonPropertyName("memoryDumpConfig")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public MemoryDumpConfig MemoryDumpConfig
        {
            get;
            set;
        }
    }
}
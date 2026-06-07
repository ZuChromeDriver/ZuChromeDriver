namespace Zu.ChromeDevTools.Tracing
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Request a global memory dump.
    /// </summary>
    public sealed class RequestMemoryDumpCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Tracing.requestMemoryDump";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Enables more deterministic results by forcing garbage collection
        /// </summary>
        [JsonPropertyName("deterministic")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Deterministic
        {
            get;
            set;
        }
        /// <summary>
        /// Specifies level of details in memory dump. Defaults to "detailed".
        /// </summary>
        [JsonPropertyName("levelOfDetail")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public MemoryDumpLevelOfDetail? LevelOfDetail
        {
            get;
            set;
        }
    }

    public sealed class RequestMemoryDumpCommandResponse : ICommandResponse<RequestMemoryDumpCommand>
    {
        /// <summary>
        /// GUID of the resulting global memory dump.
        ///</summary>
        [JsonPropertyName("dumpGuid")]
        public string DumpGuid
        {
            get;
            set;
        }
        /// <summary>
        /// True iff the global memory dump succeeded.
        ///</summary>
        [JsonPropertyName("success")]
        public bool Success
        {
            get;
            set;
        }
    }
}
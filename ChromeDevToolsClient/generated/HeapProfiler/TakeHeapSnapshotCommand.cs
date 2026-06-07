namespace Zu.ChromeDevTools.HeapProfiler
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class TakeHeapSnapshotCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "HeapProfiler.takeHeapSnapshot";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// If true 'reportHeapSnapshotProgress' events will be generated while snapshot is being taken.
        /// </summary>
        [JsonPropertyName("reportProgress")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? ReportProgress
        {
            get;
            set;
        }
        /// <summary>
        /// If true, a raw snapshot without artificial roots will be generated.
        /// Deprecated in favor of `exposeInternals`.
        /// </summary>
        [JsonPropertyName("treatGlobalObjectsAsRoots")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? TreatGlobalObjectsAsRoots
        {
            get;
            set;
        }
        /// <summary>
        /// If true, numerical values are included in the snapshot
        /// </summary>
        [JsonPropertyName("captureNumericValue")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? CaptureNumericValue
        {
            get;
            set;
        }
        /// <summary>
        /// If true, exposes internals of the snapshot.
        /// </summary>
        [JsonPropertyName("exposeInternals")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? ExposeInternals
        {
            get;
            set;
        }
    }

    public sealed class TakeHeapSnapshotCommandResponse : ICommandResponse<TakeHeapSnapshotCommand>
    {
    }
}
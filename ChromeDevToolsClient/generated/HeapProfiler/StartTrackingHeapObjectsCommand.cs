namespace Zu.ChromeDevTools.HeapProfiler
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class StartTrackingHeapObjectsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "HeapProfiler.startTrackingHeapObjects";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the trackAllocations
        /// </summary>
        [JsonPropertyName("trackAllocations")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? TrackAllocations
        {
            get;
            set;
        }
    }

    public sealed class StartTrackingHeapObjectsCommandResponse : ICommandResponse<StartTrackingHeapObjectsCommand>
    {
    }
}
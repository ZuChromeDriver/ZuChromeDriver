namespace Zu.ChromeDevTools.LayerTree
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class ProfileSnapshotCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "LayerTree.profileSnapshot";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// The id of the layer snapshot.
        /// </summary>
        [JsonPropertyName("snapshotId")]
        public string SnapshotId
        {
            get;
            set;
        }
        /// <summary>
        /// The maximum number of times to replay the snapshot (1, if not specified).
        /// </summary>
        [JsonPropertyName("minRepeatCount")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? MinRepeatCount
        {
            get;
            set;
        }
        /// <summary>
        /// The minimum duration (in seconds) to replay the snapshot.
        /// </summary>
        [JsonPropertyName("minDuration")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? MinDuration
        {
            get;
            set;
        }
        /// <summary>
        /// The clip rectangle to apply when replaying the snapshot.
        /// </summary>
        [JsonPropertyName("clipRect")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DOM.Rect ClipRect
        {
            get;
            set;
        }
    }

    public sealed class ProfileSnapshotCommandResponse : ICommandResponse<ProfileSnapshotCommand>
    {
        /// <summary>
        /// The array of paint profiles, one per run.
        ///</summary>
        [JsonPropertyName("timings")]
        public double[][] Timings
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.LayerTree
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Replays the layer snapshot and returns the resulting bitmap.
    /// </summary>
    public sealed class ReplaySnapshotCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "LayerTree.replaySnapshot";
        
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
        /// The first step to replay from (replay from the very start if not specified).
        /// </summary>
        [JsonPropertyName("fromStep")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? FromStep
        {
            get;
            set;
        }
        /// <summary>
        /// The last step to replay to (replay till the end if not specified).
        /// </summary>
        [JsonPropertyName("toStep")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? ToStep
        {
            get;
            set;
        }
        /// <summary>
        /// The scale to apply while replaying (defaults to 1).
        /// </summary>
        [JsonPropertyName("scale")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? Scale
        {
            get;
            set;
        }
    }

    public sealed class ReplaySnapshotCommandResponse : ICommandResponse<ReplaySnapshotCommand>
    {
        /// <summary>
        /// A data: URL for resulting image.
        ///</summary>
        [JsonPropertyName("dataURL")]
        public string DataURL
        {
            get;
            set;
        }
    }
}
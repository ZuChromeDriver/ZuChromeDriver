namespace Zu.ChromeDevTools.LayerTree
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Replays the layer snapshot and returns canvas log.
    /// </summary>
    public sealed class SnapshotCommandLogCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "LayerTree.snapshotCommandLog";
        
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
    }

    public sealed class SnapshotCommandLogCommandResponse : ICommandResponse<SnapshotCommandLogCommand>
    {
        /// <summary>
        /// The array of canvas function calls.
        ///</summary>
        [JsonPropertyName("commandLog")]
        public object[] CommandLog
        {
            get;
            set;
        }
    }
}
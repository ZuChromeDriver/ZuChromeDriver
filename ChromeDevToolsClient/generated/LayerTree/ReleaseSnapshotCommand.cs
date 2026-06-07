namespace Zu.ChromeDevTools.LayerTree
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Releases layer snapshot captured by the back-end.
    /// </summary>
    public sealed class ReleaseSnapshotCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "LayerTree.releaseSnapshot";
        
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

    public sealed class ReleaseSnapshotCommandResponse : ICommandResponse<ReleaseSnapshotCommand>
    {
    }
}
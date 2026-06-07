namespace Zu.ChromeDevTools.LayerTree
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns the layer snapshot identifier.
    /// </summary>
    public sealed class MakeSnapshotCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "LayerTree.makeSnapshot";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// The id of the layer.
        /// </summary>
        [JsonPropertyName("layerId")]
        public string LayerId
        {
            get;
            set;
        }
    }

    public sealed class MakeSnapshotCommandResponse : ICommandResponse<MakeSnapshotCommand>
    {
        /// <summary>
        /// The id of the layer snapshot.
        ///</summary>
        [JsonPropertyName("snapshotId")]
        public string SnapshotId
        {
            get;
            set;
        }
    }
}
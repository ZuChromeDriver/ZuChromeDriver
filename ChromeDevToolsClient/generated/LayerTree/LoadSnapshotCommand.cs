namespace Zu.ChromeDevTools.LayerTree
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns the snapshot identifier.
    /// </summary>
    public sealed class LoadSnapshotCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "LayerTree.loadSnapshot";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// An array of tiles composing the snapshot.
        /// </summary>
        [JsonPropertyName("tiles")]
        public PictureTile[] Tiles
        {
            get;
            set;
        }
    }

    public sealed class LoadSnapshotCommandResponse : ICommandResponse<LoadSnapshotCommand>
    {
        /// <summary>
        /// The id of the snapshot.
        ///</summary>
        [JsonPropertyName("snapshotId")]
        public string SnapshotId
        {
            get;
            set;
        }
    }
}
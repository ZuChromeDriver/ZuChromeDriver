namespace Zu.ChromeDevTools.Input
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class DragData
    {
        /// <summary>
        /// Gets or sets the items
        /// </summary>
        [JsonPropertyName("items")]
        public DragDataItem[] Items
        {
            get;
            set;
        }
        /// <summary>
        /// List of filenames that should be included when dropping
        ///</summary>
        [JsonPropertyName("files")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string[] Files
        {
            get;
            set;
        }
        /// <summary>
        /// Bit field representing allowed drag operations. Copy = 1, Link = 2, Move = 16
        ///</summary>
        [JsonPropertyName("dragOperationsMask")]
        public long DragOperationsMask
        {
            get;
            set;
        }
    }
}
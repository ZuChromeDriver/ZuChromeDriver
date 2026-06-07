namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// A structure to hold the top-level node of a detached tree and an array of its retained descendants.
    /// </summary>
    public sealed class DetachedElementInfo
    {
        /// <summary>
        /// Gets or sets the treeNode
        /// </summary>
        [JsonPropertyName("treeNode")]
        public Node TreeNode
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the retainedNodeIds
        /// </summary>
        [JsonPropertyName("retainedNodeIds")]
        public long[] RetainedNodeIds
        {
            get;
            set;
        }
    }
}
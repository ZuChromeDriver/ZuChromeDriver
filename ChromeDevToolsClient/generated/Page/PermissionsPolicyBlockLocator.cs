namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class PermissionsPolicyBlockLocator
    {
        /// <summary>
        /// Gets or sets the frameId
        /// </summary>
        [JsonPropertyName("frameId")]
        public string FrameId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the blockReason
        /// </summary>
        [JsonPropertyName("blockReason")]
        public PermissionsPolicyBlockReason BlockReason
        {
            get;
            set;
        }
    }
}
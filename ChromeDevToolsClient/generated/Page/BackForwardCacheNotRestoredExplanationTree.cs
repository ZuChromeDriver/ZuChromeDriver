namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class BackForwardCacheNotRestoredExplanationTree
    {
        /// <summary>
        /// URL of each frame
        ///</summary>
        [JsonPropertyName("url")]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// Not restored reasons of each frame
        ///</summary>
        [JsonPropertyName("explanations")]
        public BackForwardCacheNotRestoredExplanation[] Explanations
        {
            get;
            set;
        }
        /// <summary>
        /// Array of children frame
        ///</summary>
        [JsonPropertyName("children")]
        public BackForwardCacheNotRestoredExplanationTree[] Children
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.Target
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class TargetInfo
    {
        /// <summary>
        /// Gets or sets the targetId
        /// </summary>
        [JsonPropertyName("targetId")]
        public string TargetId
        {
            get;
            set;
        }
        /// <summary>
        /// List of types: https://source.chromium.org/chromium/chromium/src/+/main:content/browser/devtools/devtools_agent_host_impl.cc?ss=chromium&q=f:devtools%20-f:out%20%22::kTypeTab%5B%5D%22
        ///</summary>
        [JsonPropertyName("type")]
        public string Type
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the title
        /// </summary>
        [JsonPropertyName("title")]
        public string Title
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the url
        /// </summary>
        [JsonPropertyName("url")]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// Whether the target has an attached client.
        ///</summary>
        [JsonPropertyName("attached")]
        public bool Attached
        {
            get;
            set;
        }
        /// <summary>
        /// Id of the parent target, if any. For example, "iframe" target may have a "page" parent.
        ///</summary>
        [JsonPropertyName("parentId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ParentId
        {
            get;
            set;
        }
        /// <summary>
        /// Opener target Id
        ///</summary>
        [JsonPropertyName("openerId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string OpenerId
        {
            get;
            set;
        }
        /// <summary>
        /// Whether the target has access to the originating window.
        ///</summary>
        [JsonPropertyName("canAccessOpener")]
        public bool CanAccessOpener
        {
            get;
            set;
        }
        /// <summary>
        /// Frame id of originating window (is only set if target has an opener).
        ///</summary>
        [JsonPropertyName("openerFrameId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string OpenerFrameId
        {
            get;
            set;
        }
        /// <summary>
        /// Id of the parent frame, present for "iframe" and "worker" targets. For nested workers,
        /// this is the "ancestor" frame that created the first worker in the nested chain.
        ///</summary>
        [JsonPropertyName("parentFrameId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ParentFrameId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the browserContextId
        /// </summary>
        [JsonPropertyName("browserContextId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string BrowserContextId
        {
            get;
            set;
        }
        /// <summary>
        /// Provides additional details for specific target types. For example, for
        /// the type of "page", this may be set to "prerender".
        ///</summary>
        [JsonPropertyName("subtype")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Subtype
        {
            get;
            set;
        }
    }
}
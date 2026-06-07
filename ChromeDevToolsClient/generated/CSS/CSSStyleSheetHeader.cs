namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// CSS stylesheet metainformation.
    /// </summary>
    public sealed class CSSStyleSheetHeader
    {
        /// <summary>
        /// The stylesheet identifier.
        ///</summary>
        [JsonPropertyName("styleSheetId")]
        public string StyleSheetId
        {
            get;
            set;
        }
        /// <summary>
        /// Owner frame identifier.
        ///</summary>
        [JsonPropertyName("frameId")]
        public string FrameId
        {
            get;
            set;
        }
        /// <summary>
        /// Stylesheet resource URL. Empty if this is a constructed stylesheet created using
        /// new CSSStyleSheet() (but non-empty if this is a constructed stylesheet imported
        /// as a CSS module script).
        ///</summary>
        [JsonPropertyName("sourceURL")]
        public string SourceURL
        {
            get;
            set;
        }
        /// <summary>
        /// URL of source map associated with the stylesheet (if any).
        ///</summary>
        [JsonPropertyName("sourceMapURL")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string SourceMapURL
        {
            get;
            set;
        }
        /// <summary>
        /// Stylesheet origin.
        ///</summary>
        [JsonPropertyName("origin")]
        public StyleSheetOrigin Origin
        {
            get;
            set;
        }
        /// <summary>
        /// Stylesheet title.
        ///</summary>
        [JsonPropertyName("title")]
        public string Title
        {
            get;
            set;
        }
        /// <summary>
        /// The backend id for the owner node of the stylesheet.
        ///</summary>
        [JsonPropertyName("ownerNode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? OwnerNode
        {
            get;
            set;
        }
        /// <summary>
        /// Denotes whether the stylesheet is disabled.
        ///</summary>
        [JsonPropertyName("disabled")]
        public bool Disabled
        {
            get;
            set;
        }
        /// <summary>
        /// Whether the sourceURL field value comes from the sourceURL comment.
        ///</summary>
        [JsonPropertyName("hasSourceURL")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? HasSourceURL
        {
            get;
            set;
        }
        /// <summary>
        /// Whether this stylesheet is created for STYLE tag by parser. This flag is not set for
        /// document.written STYLE tags.
        ///</summary>
        [JsonPropertyName("isInline")]
        public bool IsInline
        {
            get;
            set;
        }
        /// <summary>
        /// Whether this stylesheet is mutable. Inline stylesheets become mutable
        /// after they have been modified via CSSOM API.
        /// `<link>` element's stylesheets become mutable only if DevTools modifies them.
        /// Constructed stylesheets (new CSSStyleSheet()) are mutable immediately after creation.
        ///</summary>
        [JsonPropertyName("isMutable")]
        public bool IsMutable
        {
            get;
            set;
        }
        /// <summary>
        /// True if this stylesheet is created through new CSSStyleSheet() or imported as a
        /// CSS module script.
        ///</summary>
        [JsonPropertyName("isConstructed")]
        public bool IsConstructed
        {
            get;
            set;
        }
        /// <summary>
        /// Line offset of the stylesheet within the resource (zero based).
        ///</summary>
        [JsonPropertyName("startLine")]
        public double StartLine
        {
            get;
            set;
        }
        /// <summary>
        /// Column offset of the stylesheet within the resource (zero based).
        ///</summary>
        [JsonPropertyName("startColumn")]
        public double StartColumn
        {
            get;
            set;
        }
        /// <summary>
        /// Size of the content (in characters).
        ///</summary>
        [JsonPropertyName("length")]
        public double Length
        {
            get;
            set;
        }
        /// <summary>
        /// Line offset of the end of the stylesheet within the resource (zero based).
        ///</summary>
        [JsonPropertyName("endLine")]
        public double EndLine
        {
            get;
            set;
        }
        /// <summary>
        /// Column offset of the end of the stylesheet within the resource (zero based).
        ///</summary>
        [JsonPropertyName("endColumn")]
        public double EndColumn
        {
            get;
            set;
        }
        /// <summary>
        /// If the style sheet was loaded from a network resource, this indicates when the resource failed to load
        ///</summary>
        [JsonPropertyName("loadingFailed")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? LoadingFailed
        {
            get;
            set;
        }
    }
}
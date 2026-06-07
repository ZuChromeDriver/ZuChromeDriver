namespace Zu.ChromeDevTools.Debugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when virtual machine fails to parse the script.
    /// </summary>
    public sealed class ScriptFailedToParseEvent : IEvent
    {
        /// <summary>
        /// Identifier of the script parsed.
        /// </summary>
        [JsonPropertyName("scriptId")]
        public string ScriptId
        {
            get;
            set;
        }
        /// <summary>
        /// URL or name of the script parsed (if any).
        /// </summary>
        [JsonPropertyName("url")]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// Line offset of the script within the resource with given URL (for script tags).
        /// </summary>
        [JsonPropertyName("startLine")]
        public long StartLine
        {
            get;
            set;
        }
        /// <summary>
        /// Column offset of the script within the resource with given URL.
        /// </summary>
        [JsonPropertyName("startColumn")]
        public long StartColumn
        {
            get;
            set;
        }
        /// <summary>
        /// Last line of the script.
        /// </summary>
        [JsonPropertyName("endLine")]
        public long EndLine
        {
            get;
            set;
        }
        /// <summary>
        /// Length of the last line of the script.
        /// </summary>
        [JsonPropertyName("endColumn")]
        public long EndColumn
        {
            get;
            set;
        }
        /// <summary>
        /// Specifies script creation context.
        /// </summary>
        [JsonPropertyName("executionContextId")]
        public long ExecutionContextId
        {
            get;
            set;
        }
        /// <summary>
        /// Content hash of the script, SHA-256.
        /// </summary>
        [JsonPropertyName("hash")]
        public string Hash
        {
            get;
            set;
        }
        /// <summary>
        /// For Wasm modules, the content of the `build_id` custom section. For JavaScript the `debugId` magic comment.
        /// </summary>
        [JsonPropertyName("buildId")]
        public string BuildId
        {
            get;
            set;
        }
        /// <summary>
        /// Embedder-specific auxiliary data likely matching {isDefault: boolean, type: 'default'|'isolated'|'worker', frameId: string}
        /// </summary>
        [JsonPropertyName("executionContextAuxData")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public object ExecutionContextAuxData
        {
            get;
            set;
        }
        /// <summary>
        /// URL of source map associated with script (if any).
        /// </summary>
        [JsonPropertyName("sourceMapURL")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string SourceMapURL
        {
            get;
            set;
        }
        /// <summary>
        /// True, if this script has sourceURL.
        /// </summary>
        [JsonPropertyName("hasSourceURL")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? HasSourceURL
        {
            get;
            set;
        }
        /// <summary>
        /// True, if this script is ES6 module.
        /// </summary>
        [JsonPropertyName("isModule")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? IsModule
        {
            get;
            set;
        }
        /// <summary>
        /// This script length.
        /// </summary>
        [JsonPropertyName("length")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Length
        {
            get;
            set;
        }
        /// <summary>
        /// JavaScript top stack frame of where the script parsed event was triggered if available.
        /// </summary>
        [JsonPropertyName("stackTrace")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Runtime.StackTrace StackTrace
        {
            get;
            set;
        }
        /// <summary>
        /// If the scriptLanguage is WebAssembly, the code section offset in the module.
        /// </summary>
        [JsonPropertyName("codeOffset")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? CodeOffset
        {
            get;
            set;
        }
        /// <summary>
        /// The language of the script.
        /// </summary>
        [JsonPropertyName("scriptLanguage")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Debugger.ScriptLanguage? ScriptLanguage
        {
            get;
            set;
        }
        /// <summary>
        /// The name the embedder supplied for this script.
        /// </summary>
        [JsonPropertyName("embedderName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string EmbedderName
        {
            get;
            set;
        }
    }
}
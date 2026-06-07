namespace Zu.ChromeDevTools.Debugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Sets JavaScript breakpoint at given location specified either by URL or URL regex. Once this
    /// command is issued, all existing parsed scripts will have breakpoints resolved and returned in
    /// `locations` property. Further matching script parsing will result in subsequent
    /// `breakpointResolved` events issued. This logical breakpoint will survive page reloads.
    /// </summary>
    public sealed class SetBreakpointByUrlCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Debugger.setBreakpointByUrl";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Line number to set breakpoint at.
        /// </summary>
        [JsonPropertyName("lineNumber")]
        public long LineNumber
        {
            get;
            set;
        }
        /// <summary>
        /// URL of the resources to set breakpoint on.
        /// </summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// Regex pattern for the URLs of the resources to set breakpoints on. Either `url` or
        /// `urlRegex` must be specified.
        /// </summary>
        [JsonPropertyName("urlRegex")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string UrlRegex
        {
            get;
            set;
        }
        /// <summary>
        /// Script hash of the resources to set breakpoint on.
        /// </summary>
        [JsonPropertyName("scriptHash")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ScriptHash
        {
            get;
            set;
        }
        /// <summary>
        /// Offset in the line to set breakpoint at.
        /// </summary>
        [JsonPropertyName("columnNumber")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? ColumnNumber
        {
            get;
            set;
        }
        /// <summary>
        /// Expression to use as a breakpoint condition. When specified, debugger will only stop on the
        /// breakpoint if this expression evaluates to true.
        /// </summary>
        [JsonPropertyName("condition")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Condition
        {
            get;
            set;
        }
    }

    public sealed class SetBreakpointByUrlCommandResponse : ICommandResponse<SetBreakpointByUrlCommand>
    {
        /// <summary>
        /// Id of the created breakpoint for further reference.
        ///</summary>
        [JsonPropertyName("breakpointId")]
        public string BreakpointId
        {
            get;
            set;
        }
        /// <summary>
        /// List of the locations this breakpoint resolved into upon addition.
        ///</summary>
        [JsonPropertyName("locations")]
        public Location[] Locations
        {
            get;
            set;
        }
    }
}
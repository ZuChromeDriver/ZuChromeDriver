namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Searches for given string in resource content.
    /// </summary>
    public sealed class SearchInResourceCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.searchInResource";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Frame id for resource to search in.
        /// </summary>
        [JsonPropertyName("frameId")]
        public string FrameId
        {
            get;
            set;
        }
        /// <summary>
        /// URL of the resource to search in.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// String to search for.
        /// </summary>
        [JsonPropertyName("query")]
        public string Query
        {
            get;
            set;
        }
        /// <summary>
        /// If true, search is case sensitive.
        /// </summary>
        [JsonPropertyName("caseSensitive")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? CaseSensitive
        {
            get;
            set;
        }
        /// <summary>
        /// If true, treats string parameter as regex.
        /// </summary>
        [JsonPropertyName("isRegex")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? IsRegex
        {
            get;
            set;
        }
    }

    public sealed class SearchInResourceCommandResponse : ICommandResponse<SearchInResourceCommand>
    {
        /// <summary>
        /// List of search matches.
        ///</summary>
        [JsonPropertyName("result")]
        public Debugger.SearchMatch[] Result
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.Debugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Searches for given string in script content.
    /// </summary>
    public sealed class SearchInContentCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Debugger.searchInContent";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Id of the script to search in.
        /// </summary>
        [JsonPropertyName("scriptId")]
        public string ScriptId
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

    public sealed class SearchInContentCommandResponse : ICommandResponse<SearchInContentCommand>
    {
        /// <summary>
        /// List of search matches.
        ///</summary>
        [JsonPropertyName("result")]
        public SearchMatch[] Result
        {
            get;
            set;
        }
    }
}
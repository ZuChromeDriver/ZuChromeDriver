namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Searches for given string in response content.
    /// </summary>
    public sealed class SearchInResponseBodyCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Network.searchInResponseBody";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Identifier of the network response to search.
        /// </summary>
        [JsonPropertyName("requestId")]
        public string RequestId
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

    public sealed class SearchInResponseBodyCommandResponse : ICommandResponse<SearchInResponseBodyCommand>
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
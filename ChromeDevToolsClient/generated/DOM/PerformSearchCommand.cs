namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Searches for a given string in the DOM tree. Use `getSearchResults` to access search results or
    /// `cancelSearch` to end this search session.
    /// </summary>
    public sealed class PerformSearchCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOM.performSearch";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Plain text or query selector or XPath search query.
        /// </summary>
        [JsonPropertyName("query")]
        public string Query
        {
            get;
            set;
        }
        /// <summary>
        /// True to search in user agent shadow DOM.
        /// </summary>
        [JsonPropertyName("includeUserAgentShadowDOM")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? IncludeUserAgentShadowDOM
        {
            get;
            set;
        }
    }

    public sealed class PerformSearchCommandResponse : ICommandResponse<PerformSearchCommand>
    {
        /// <summary>
        /// Unique search session identifier.
        ///</summary>
        [JsonPropertyName("searchId")]
        public string SearchId
        {
            get;
            set;
        }
        /// <summary>
        /// Number of search results.
        ///</summary>
        [JsonPropertyName("resultCount")]
        public long ResultCount
        {
            get;
            set;
        }
    }
}
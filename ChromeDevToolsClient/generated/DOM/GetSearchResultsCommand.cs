namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns search results from given `fromIndex` to given `toIndex` from the search with the given
    /// identifier.
    /// </summary>
    public sealed class GetSearchResultsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOM.getSearchResults";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Unique search session identifier.
        /// </summary>
        [JsonPropertyName("searchId")]
        public string SearchId
        {
            get;
            set;
        }
        /// <summary>
        /// Start index of the search result to be returned.
        /// </summary>
        [JsonPropertyName("fromIndex")]
        public long FromIndex
        {
            get;
            set;
        }
        /// <summary>
        /// End index of the search result to be returned.
        /// </summary>
        [JsonPropertyName("toIndex")]
        public long ToIndex
        {
            get;
            set;
        }
    }

    public sealed class GetSearchResultsCommandResponse : ICommandResponse<GetSearchResultsCommand>
    {
        /// <summary>
        /// Ids of the search result nodes.
        ///</summary>
        [JsonPropertyName("nodeIds")]
        public long[] NodeIds
        {
            get;
            set;
        }
    }
}
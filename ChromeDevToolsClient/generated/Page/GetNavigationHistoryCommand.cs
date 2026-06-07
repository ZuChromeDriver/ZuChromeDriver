namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns navigation history for the current page.
    /// </summary>
    public sealed class GetNavigationHistoryCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.getNavigationHistory";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class GetNavigationHistoryCommandResponse : ICommandResponse<GetNavigationHistoryCommand>
    {
        /// <summary>
        /// Index of the current navigation history entry.
        ///</summary>
        [JsonPropertyName("currentIndex")]
        public long CurrentIndex
        {
            get;
            set;
        }
        /// <summary>
        /// Array of navigation history entries.
        ///</summary>
        [JsonPropertyName("entries")]
        public NavigationEntry[] Entries
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Navigates current page to the given history entry.
    /// </summary>
    public sealed class NavigateToHistoryEntryCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.navigateToHistoryEntry";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Unique id of the entry to navigate to.
        /// </summary>
        [JsonPropertyName("entryId")]
        public long EntryId
        {
            get;
            set;
        }
    }

    public sealed class NavigateToHistoryEntryCommandResponse : ICommandResponse<NavigateToHistoryEntryCommand>
    {
    }
}
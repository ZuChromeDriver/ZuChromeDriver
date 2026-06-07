namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Blocks URLs from loading.
    /// </summary>
    public sealed class SetBlockedURLsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Network.setBlockedURLs";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Patterns to match in the order in which they are given. These patterns
        /// also take precedence over any wildcard patterns defined in `urls`.
        /// </summary>
        [JsonPropertyName("urlPatterns")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public BlockPattern[] UrlPatterns
        {
            get;
            set;
        }
        /// <summary>
        /// URL patterns to block. Wildcards ('*') are allowed.
        /// </summary>
        [JsonPropertyName("urls")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string[] Urls
        {
            get;
            set;
        }
    }

    public sealed class SetBlockedURLsCommandResponse : ICommandResponse<SetBlockedURLsCommand>
    {
    }
}
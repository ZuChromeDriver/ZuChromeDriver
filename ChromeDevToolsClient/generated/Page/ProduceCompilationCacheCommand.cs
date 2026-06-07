namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Requests backend to produce compilation cache for the specified scripts.
    /// `scripts` are appended to the list of scripts for which the cache
    /// would be produced. The list may be reset during page navigation.
    /// When script with a matching URL is encountered, the cache is optionally
    /// produced upon backend discretion, based on internal heuristics.
    /// See also: `Page.compilationCacheProduced`.
    /// </summary>
    public sealed class ProduceCompilationCacheCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.produceCompilationCache";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the scripts
        /// </summary>
        [JsonPropertyName("scripts")]
        public CompilationCacheParams[] Scripts
        {
            get;
            set;
        }
    }

    public sealed class ProduceCompilationCacheCommandResponse : ICommandResponse<ProduceCompilationCacheCommand>
    {
    }
}
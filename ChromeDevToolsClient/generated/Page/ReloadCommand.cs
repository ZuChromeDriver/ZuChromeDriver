namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Reloads given page optionally ignoring the cache.
    /// </summary>
    public sealed class ReloadCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.reload";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// If true, browser cache is ignored (as if the user pressed Shift+refresh).
        /// </summary>
        [JsonPropertyName("ignoreCache")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? IgnoreCache
        {
            get;
            set;
        }
        /// <summary>
        /// If set, the script will be injected into all frames of the inspected page after reload.
        /// Argument will be ignored if reloading dataURL origin.
        /// </summary>
        [JsonPropertyName("scriptToEvaluateOnLoad")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ScriptToEvaluateOnLoad
        {
            get;
            set;
        }
        /// <summary>
        /// If set, an error will be thrown if the target page's main frame's
        /// loader id does not match the provided id. This prevents accidentally
        /// reloading an unintended target in case there's a racing navigation.
        /// </summary>
        [JsonPropertyName("loaderId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string LoaderId
        {
            get;
            set;
        }
    }

    public sealed class ReloadCommandResponse : ICommandResponse<ReloadCommand>
    {
    }
}
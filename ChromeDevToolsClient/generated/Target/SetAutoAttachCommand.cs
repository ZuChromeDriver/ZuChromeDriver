namespace Zu.ChromeDevTools.Target
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Controls whether to automatically attach to new targets which are considered
    /// to be directly related to this one (for example, iframes or workers).
    /// When turned on, attaches to all existing related targets as well. When turned off,
    /// automatically detaches from all currently attached targets.
    /// This also clears all targets added by `autoAttachRelated` from the list of targets to watch
    /// for creation of related targets.
    /// You might want to call this recursively for auto-attached targets to attach
    /// to all available targets.
    /// </summary>
    public sealed class SetAutoAttachCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Target.setAutoAttach";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Whether to auto-attach to related targets.
        /// </summary>
        [JsonPropertyName("autoAttach")]
        public bool AutoAttach
        {
            get;
            set;
        }
        /// <summary>
        /// Whether to pause new targets when attaching to them. Use `Runtime.runIfWaitingForDebugger`
        /// to run paused targets.
        /// </summary>
        [JsonPropertyName("waitForDebuggerOnStart")]
        public bool WaitForDebuggerOnStart
        {
            get;
            set;
        }
        /// <summary>
        /// Enables "flat" access to the session via specifying sessionId attribute in the commands.
        /// We plan to make this the default, deprecate non-flattened mode,
        /// and eventually retire it. See crbug.com/991325.
        /// </summary>
        [JsonPropertyName("flatten")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Flatten
        {
            get;
            set;
        }
        /// <summary>
        /// Only targets matching filter will be attached.
        /// </summary>
        [JsonPropertyName("filter")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public FilterEntry[] Filter
        {
            get;
            set;
        }
    }

    public sealed class SetAutoAttachCommandResponse : ICommandResponse<SetAutoAttachCommand>
    {
    }
}
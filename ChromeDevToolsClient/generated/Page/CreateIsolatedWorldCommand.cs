namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Creates an isolated world for the given frame.
    /// </summary>
    public sealed class CreateIsolatedWorldCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.createIsolatedWorld";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Id of the frame in which the isolated world should be created.
        /// </summary>
        [JsonPropertyName("frameId")]
        public string FrameId
        {
            get;
            set;
        }
        /// <summary>
        /// An optional name which is reported in the Execution Context.
        /// </summary>
        [JsonPropertyName("worldName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string WorldName
        {
            get;
            set;
        }
        /// <summary>
        /// Whether or not universal access should be granted to the isolated world. This is a powerful
        /// option, use with caution.
        /// </summary>
        [JsonPropertyName("grantUniveralAccess")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? GrantUniveralAccess
        {
            get;
            set;
        }
    }

    public sealed class CreateIsolatedWorldCommandResponse : ICommandResponse<CreateIsolatedWorldCommand>
    {
        /// <summary>
        /// Execution context of the isolated world.
        ///</summary>
        [JsonPropertyName("executionContextId")]
        public long ExecutionContextId
        {
            get;
            set;
        }
    }
}
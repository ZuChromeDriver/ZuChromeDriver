namespace Zu.ChromeDevTools.WebMCP
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Invokes a registered tool.
    /// </summary>
    public sealed class InvokeToolCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "WebMCP.invokeTool";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Frame in which to invoke the tool.
        /// </summary>
        [JsonPropertyName("frameId")]
        public string FrameId
        {
            get;
            set;
        }
        /// <summary>
        /// Name of the tool to invoke.
        /// </summary>
        [JsonPropertyName("toolName")]
        public string ToolName
        {
            get;
            set;
        }
        /// <summary>
        /// Input parameters for the tool, matching the tool's inputSchema.
        /// </summary>
        [JsonPropertyName("input")]
        public object Input
        {
            get;
            set;
        }
    }

    public sealed class InvokeToolCommandResponse : ICommandResponse<InvokeToolCommand>
    {
        /// <summary>
        /// Unique identifier for this invocation. Response is sent before tool events.
        ///</summary>
        [JsonPropertyName("invocationId")]
        public string InvocationId
        {
            get;
            set;
        }
    }
}
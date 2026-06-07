namespace Zu.ChromeDevTools.Debugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// This command is deprecated. Use getScriptSource instead.
    /// </summary>
    public sealed class GetWasmBytecodeCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Debugger.getWasmBytecode";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Id of the Wasm script to get source for.
        /// </summary>
        [JsonPropertyName("scriptId")]
        public string ScriptId
        {
            get;
            set;
        }
    }

    public sealed class GetWasmBytecodeCommandResponse : ICommandResponse<GetWasmBytecodeCommand>
    {
        /// <summary>
        /// Script source. (Encoded as a base64 string when passed over JSON)
        ///</summary>
        [JsonPropertyName("bytecode")]
        public string Bytecode
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.Debugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class DisassembleWasmModuleCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Debugger.disassembleWasmModule";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Id of the script to disassemble
        /// </summary>
        [JsonPropertyName("scriptId")]
        public string ScriptId
        {
            get;
            set;
        }
    }

    public sealed class DisassembleWasmModuleCommandResponse : ICommandResponse<DisassembleWasmModuleCommand>
    {
        /// <summary>
        /// For large modules, return a stream from which additional chunks of
        /// disassembly can be read successively.
        ///</summary>
        [JsonPropertyName("streamId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string StreamId
        {
            get;
            set;
        }
        /// <summary>
        /// The total number of lines in the disassembly text.
        ///</summary>
        [JsonPropertyName("totalNumberOfLines")]
        public long TotalNumberOfLines
        {
            get;
            set;
        }
        /// <summary>
        /// The offsets of all function bodies, in the format [start1, end1,
        /// start2, end2, ...] where all ends are exclusive.
        ///</summary>
        [JsonPropertyName("functionBodyOffsets")]
        public long[] FunctionBodyOffsets
        {
            get;
            set;
        }
        /// <summary>
        /// The first chunk of disassembly.
        ///</summary>
        [JsonPropertyName("chunk")]
        public WasmDisassemblyChunk Chunk
        {
            get;
            set;
        }
    }
}
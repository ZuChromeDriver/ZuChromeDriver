namespace Zu.ChromeDevTools.Debugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class WasmDisassemblyChunk
    {
        /// <summary>
        /// The next chunk of disassembled lines.
        ///</summary>
        [JsonPropertyName("lines")]
        public string[] Lines
        {
            get;
            set;
        }
        /// <summary>
        /// The bytecode offsets describing the start of each line.
        ///</summary>
        [JsonPropertyName("bytecodeOffsets")]
        public long[] BytecodeOffsets
        {
            get;
            set;
        }
    }
}
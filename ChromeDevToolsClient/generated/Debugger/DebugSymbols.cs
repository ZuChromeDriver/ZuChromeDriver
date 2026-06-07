namespace Zu.ChromeDevTools.Debugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Debug symbols available for a wasm script.
    /// </summary>
    public sealed class DebugSymbols
    {
        /// <summary>
        /// Type of the debug symbols.
        ///</summary>
        [JsonPropertyName("type")]
        public string Type
        {
            get;
            set;
        }
        /// <summary>
        /// URL of the external symbol source.
        ///</summary>
        [JsonPropertyName("externalURL")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ExternalURL
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Identifies the script on the stack that caused a resource or element to be
    /// labeled as an ad. For resources, this indicates the context that triggered
    /// the fetch. For elements, this indicates the context that caused the element
    /// to be appended to the DOM.
    /// </summary>
    public sealed class AdScriptIdentifier
    {
        /// <summary>
        /// The script's V8 identifier.
        ///</summary>
        [JsonPropertyName("scriptId")]
        public string ScriptId
        {
            get;
            set;
        }
        /// <summary>
        /// V8's debugging ID for the v8::Context.
        ///</summary>
        [JsonPropertyName("debuggerId")]
        public string DebuggerId
        {
            get;
            set;
        }
        /// <summary>
        /// The script's url (or generated name based on id if inline script).
        ///</summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
    }
}
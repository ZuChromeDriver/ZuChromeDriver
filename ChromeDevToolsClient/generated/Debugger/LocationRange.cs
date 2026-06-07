namespace Zu.ChromeDevTools.Debugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Location range within one script.
    /// </summary>
    public sealed class LocationRange
    {
        /// <summary>
        /// Gets or sets the scriptId
        /// </summary>
        [JsonPropertyName("scriptId")]
        public string ScriptId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the start
        /// </summary>
        [JsonPropertyName("start")]
        public ScriptPosition Start
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the end
        /// </summary>
        [JsonPropertyName("end")]
        public ScriptPosition End
        {
            get;
            set;
        }
    }
}
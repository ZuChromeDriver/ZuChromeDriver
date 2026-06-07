namespace Zu.ChromeDevTools.Profiler
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Coverage data for a JavaScript script.
    /// </summary>
    public sealed class ScriptCoverage
    {
        /// <summary>
        /// JavaScript script id.
        ///</summary>
        [JsonPropertyName("scriptId")]
        public string ScriptId
        {
            get;
            set;
        }
        /// <summary>
        /// JavaScript script name or url.
        ///</summary>
        [JsonPropertyName("url")]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// Functions contained in the script that has coverage data.
        ///</summary>
        [JsonPropertyName("functions")]
        public FunctionCoverage[] Functions
        {
            get;
            set;
        }
    }
}
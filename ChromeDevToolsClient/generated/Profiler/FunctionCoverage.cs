namespace Zu.ChromeDevTools.Profiler
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Coverage data for a JavaScript function.
    /// </summary>
    public sealed class FunctionCoverage
    {
        /// <summary>
        /// JavaScript function name.
        ///</summary>
        [JsonPropertyName("functionName")]
        public string FunctionName
        {
            get;
            set;
        }
        /// <summary>
        /// Source ranges inside the function with coverage data.
        ///</summary>
        [JsonPropertyName("ranges")]
        public CoverageRange[] Ranges
        {
            get;
            set;
        }
        /// <summary>
        /// Whether coverage data for this function has block granularity.
        ///</summary>
        [JsonPropertyName("isBlockCoverage")]
        public bool IsBlockCoverage
        {
            get;
            set;
        }
    }
}
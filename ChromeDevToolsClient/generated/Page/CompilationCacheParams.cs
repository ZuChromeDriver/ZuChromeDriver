namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Per-script compilation cache parameters for `Page.produceCompilationCache`
    /// </summary>
    public sealed class CompilationCacheParams
    {
        /// <summary>
        /// The URL of the script to produce a compilation cache entry for.
        ///</summary>
        [JsonPropertyName("url")]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// A hint to the backend whether eager compilation is recommended.
        /// (the actual compilation mode used is upon backend discretion).
        ///</summary>
        [JsonPropertyName("eager")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Eager
        {
            get;
            set;
        }
    }
}
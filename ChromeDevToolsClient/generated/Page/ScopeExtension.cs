namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class ScopeExtension
    {
        /// <summary>
        /// Instead of using tuple, this field always returns the serialized string
        /// for easy understanding and comparison.
        ///</summary>
        [JsonPropertyName("origin")]
        public string Origin
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the hasOriginWildcard
        /// </summary>
        [JsonPropertyName("hasOriginWildcard")]
        public bool HasOriginWildcard
        {
            get;
            set;
        }
    }
}
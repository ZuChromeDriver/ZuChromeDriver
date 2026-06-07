namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Media query descriptor.
    /// </summary>
    public sealed class MediaQuery
    {
        /// <summary>
        /// Array of media query expressions.
        ///</summary>
        [JsonPropertyName("expressions")]
        public MediaQueryExpression[] Expressions
        {
            get;
            set;
        }
        /// <summary>
        /// Whether the media query condition is satisfied.
        ///</summary>
        [JsonPropertyName("active")]
        public bool Active
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Specificity:
    /// https://drafts.csswg.org/selectors/#specificity-rules
    /// </summary>
    public sealed class Specificity
    {
        /// <summary>
        /// The a component, which represents the number of ID selectors.
        ///</summary>
        [JsonPropertyName("a")]
        public long A
        {
            get;
            set;
        }
        /// <summary>
        /// The b component, which represents the number of class selectors, attributes selectors, and
        /// pseudo-classes.
        ///</summary>
        [JsonPropertyName("b")]
        public long B
        {
            get;
            set;
        }
        /// <summary>
        /// The c component, which represents the number of type selectors and pseudo-elements.
        ///</summary>
        [JsonPropertyName("c")]
        public long C
        {
            get;
            set;
        }
    }
}
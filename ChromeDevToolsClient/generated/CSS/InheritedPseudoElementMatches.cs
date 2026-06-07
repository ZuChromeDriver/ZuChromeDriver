namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Inherited pseudo element matches from pseudos of an ancestor node.
    /// </summary>
    public sealed class InheritedPseudoElementMatches
    {
        /// <summary>
        /// Matches of pseudo styles from the pseudos of an ancestor node.
        ///</summary>
        [JsonPropertyName("pseudoElements")]
        public PseudoElementMatches[] PseudoElements
        {
            get;
            set;
        }
    }
}
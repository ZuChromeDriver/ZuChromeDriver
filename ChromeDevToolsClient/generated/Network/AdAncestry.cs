namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Encapsulates the script ancestry and the root script filter list rule that
    /// caused the resource or element to be labeled as an ad.
    /// </summary>
    public sealed class AdAncestry
    {
        /// <summary>
        /// A chain of `AdScriptIdentifier`s representing the ancestry of an ad
        /// script that led to the creation of a resource or element. The chain is
        /// ordered from the script itself (lowest level) up to its root ancestor
        /// that was flagged by a filter list.
        ///</summary>
        [JsonPropertyName("ancestryChain")]
        public AdScriptIdentifier[] AncestryChain
        {
            get;
            set;
        }
        /// <summary>
        /// The filter list rule that caused the root (last) script in
        /// `ancestryChain` to be tagged as an ad.
        ///</summary>
        [JsonPropertyName("rootScriptFilterlistRule")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string RootScriptFilterlistRule
        {
            get;
            set;
        }
    }
}
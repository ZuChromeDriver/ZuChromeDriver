namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Selector list data.
    /// </summary>
    public sealed class SelectorList
    {
        /// <summary>
        /// Selectors in the list.
        ///</summary>
        [JsonPropertyName("selectors")]
        public Value[] Selectors
        {
            get;
            set;
        }
        /// <summary>
        /// Rule selector text.
        ///</summary>
        [JsonPropertyName("text")]
        public string Text
        {
            get;
            set;
        }
    }
}
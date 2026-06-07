namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class ShorthandEntry
    {
        /// <summary>
        /// Shorthand name.
        ///</summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Shorthand value.
        ///</summary>
        [JsonPropertyName("value")]
        public string Value
        {
            get;
            set;
        }
        /// <summary>
        /// Whether the property has "!important" annotation (implies `false` if absent).
        ///</summary>
        [JsonPropertyName("important")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Important
        {
            get;
            set;
        }
    }
}
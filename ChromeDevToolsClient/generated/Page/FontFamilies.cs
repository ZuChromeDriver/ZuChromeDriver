namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Generic font families collection.
    /// </summary>
    public sealed class FontFamilies
    {
        /// <summary>
        /// The standard font-family.
        ///</summary>
        [JsonPropertyName("standard")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Standard
        {
            get;
            set;
        }
        /// <summary>
        /// The fixed font-family.
        ///</summary>
        [JsonPropertyName("fixed")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Fixed
        {
            get;
            set;
        }
        /// <summary>
        /// The serif font-family.
        ///</summary>
        [JsonPropertyName("serif")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Serif
        {
            get;
            set;
        }
        /// <summary>
        /// The sansSerif font-family.
        ///</summary>
        [JsonPropertyName("sansSerif")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string SansSerif
        {
            get;
            set;
        }
        /// <summary>
        /// The cursive font-family.
        ///</summary>
        [JsonPropertyName("cursive")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Cursive
        {
            get;
            set;
        }
        /// <summary>
        /// The fantasy font-family.
        ///</summary>
        [JsonPropertyName("fantasy")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Fantasy
        {
            get;
            set;
        }
        /// <summary>
        /// The math font-family.
        ///</summary>
        [JsonPropertyName("math")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Math
        {
            get;
            set;
        }
    }
}
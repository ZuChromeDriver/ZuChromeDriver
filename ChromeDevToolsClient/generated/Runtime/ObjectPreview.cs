namespace Zu.ChromeDevTools.Runtime
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Object containing abbreviated remote object value.
    /// </summary>
    public sealed class ObjectPreview
    {
        /// <summary>
        /// Object type.
        ///</summary>
        [JsonPropertyName("type")]
        public string Type
        {
            get;
            set;
        }
        /// <summary>
        /// Object subtype hint. Specified for `object` type values only.
        ///</summary>
        [JsonPropertyName("subtype")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Subtype
        {
            get;
            set;
        }
        /// <summary>
        /// String representation of the object.
        ///</summary>
        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Description
        {
            get;
            set;
        }
        /// <summary>
        /// True iff some of the properties or entries of the original object did not fit.
        ///</summary>
        [JsonPropertyName("overflow")]
        public bool Overflow
        {
            get;
            set;
        }
        /// <summary>
        /// List of the properties.
        ///</summary>
        [JsonPropertyName("properties")]
        public PropertyPreview[] Properties
        {
            get;
            set;
        }
        /// <summary>
        /// List of the entries. Specified for `map` and `set` subtype values only.
        ///</summary>
        [JsonPropertyName("entries")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public EntryPreview[] Entries
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.DOMSnapshot
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// A name/value pair.
    /// </summary>
    public sealed class NameValue
    {
        /// <summary>
        /// Attribute/property name.
        ///</summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Attribute/property value.
        ///</summary>
        [JsonPropertyName("value")]
        public string Value
        {
            get;
            set;
        }
    }
}
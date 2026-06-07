namespace Zu.ChromeDevTools.Target
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// A filter used by target query/discovery/auto-attach operations.
    /// </summary>
    public sealed class FilterEntry
    {
        /// <summary>
        /// If set, causes exclusion of matching targets from the list.
        ///</summary>
        [JsonPropertyName("exclude")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Exclude
        {
            get;
            set;
        }
        /// <summary>
        /// If not present, matches any type.
        ///</summary>
        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Type
        {
            get;
            set;
        }
    }
}
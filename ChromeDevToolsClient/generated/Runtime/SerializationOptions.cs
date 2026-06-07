namespace Zu.ChromeDevTools.Runtime
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents options for serialization. Overrides `generatePreview` and `returnByValue`.
    /// </summary>
    public sealed class SerializationOptions
    {
        /// <summary>
        /// Gets or sets the serialization
        /// </summary>
        [JsonPropertyName("serialization")]
        public string Serialization
        {
            get;
            set;
        }
        /// <summary>
        /// Deep serialization depth. Default is full depth. Respected only in `deep` serialization mode.
        ///</summary>
        [JsonPropertyName("maxDepth")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? MaxDepth
        {
            get;
            set;
        }
        /// <summary>
        /// Embedder-specific parameters. For example if connected to V8 in Chrome these control DOM
        /// serialization via `maxNodeDepth: integer` and `includeShadowTree: "none" | "open" | "all"`.
        /// Values can be only of type string or integer.
        ///</summary>
        [JsonPropertyName("additionalParameters")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public object AdditionalParameters
        {
            get;
            set;
        }
    }
}
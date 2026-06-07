namespace Zu.ChromeDevTools.Preload
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when a preload enabled state is updated.
    /// </summary>
    public sealed class PreloadEnabledStateUpdatedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the disabledByPreference
        /// </summary>
        [JsonPropertyName("disabledByPreference")]
        public bool DisabledByPreference
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the disabledByDataSaver
        /// </summary>
        [JsonPropertyName("disabledByDataSaver")]
        public bool DisabledByDataSaver
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the disabledByBatterySaver
        /// </summary>
        [JsonPropertyName("disabledByBatterySaver")]
        public bool DisabledByBatterySaver
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the disabledByHoldbackPrefetchSpeculationRules
        /// </summary>
        [JsonPropertyName("disabledByHoldbackPrefetchSpeculationRules")]
        public bool DisabledByHoldbackPrefetchSpeculationRules
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the disabledByHoldbackPrerenderSpeculationRules
        /// </summary>
        [JsonPropertyName("disabledByHoldbackPrerenderSpeculationRules")]
        public bool DisabledByHoldbackPrerenderSpeculationRules
        {
            get;
            set;
        }
    }
}
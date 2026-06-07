namespace Zu.ChromeDevTools.Preload
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Upsert. Currently, it is only emitted when a rule set added.
    /// </summary>
    public sealed class RuleSetUpdatedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the ruleSet
        /// </summary>
        [JsonPropertyName("ruleSet")]
        public RuleSet RuleSet
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Triggered when a device bound session event occurs.
    /// </summary>
    public sealed class DeviceBoundSessionEventOccurredEvent : IEvent
    {
        /// <summary>
        /// A unique identifier for this session event.
        /// </summary>
        [JsonPropertyName("eventId")]
        public string EventId
        {
            get;
            set;
        }
        /// <summary>
        /// The site this session event is associated with.
        /// </summary>
        [JsonPropertyName("site")]
        public string Site
        {
            get;
            set;
        }
        /// <summary>
        /// Whether this event was considered successful.
        /// </summary>
        [JsonPropertyName("succeeded")]
        public bool Succeeded
        {
            get;
            set;
        }
        /// <summary>
        /// The session ID this event is associated with. May not be populated for
        /// failed events.
        /// </summary>
        [JsonPropertyName("sessionId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string SessionId
        {
            get;
            set;
        }
        /// <summary>
        /// The below are the different session event type details. Exactly one is populated.
        /// </summary>
        [JsonPropertyName("creationEventDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CreationEventDetails CreationEventDetails
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the refreshEventDetails
        /// </summary>
        [JsonPropertyName("refreshEventDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public RefreshEventDetails RefreshEventDetails
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the terminationEventDetails
        /// </summary>
        [JsonPropertyName("terminationEventDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public TerminationEventDetails TerminationEventDetails
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the challengeEventDetails
        /// </summary>
        [JsonPropertyName("challengeEventDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ChallengeEventDetails ChallengeEventDetails
        {
            get;
            set;
        }
    }
}
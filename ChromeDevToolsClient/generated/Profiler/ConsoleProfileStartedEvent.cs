namespace Zu.ChromeDevTools.Profiler
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Sent when new profile recording is started using console.profile() call.
    /// </summary>
    public sealed class ConsoleProfileStartedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id
        {
            get;
            set;
        }
        /// <summary>
        /// Location of console.profile().
        /// </summary>
        [JsonPropertyName("location")]
        public Debugger.Location Location
        {
            get;
            set;
        }
        /// <summary>
        /// Profile title passed as an argument to console.profile().
        /// </summary>
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Title
        {
            get;
            set;
        }
    }
}
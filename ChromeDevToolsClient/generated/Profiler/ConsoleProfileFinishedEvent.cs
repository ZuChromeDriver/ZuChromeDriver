namespace Zu.ChromeDevTools.Profiler
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class ConsoleProfileFinishedEvent : IEvent
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
        /// Location of console.profileEnd().
        /// </summary>
        [JsonPropertyName("location")]
        public Debugger.Location Location
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the profile
        /// </summary>
        [JsonPropertyName("profile")]
        public Profile Profile
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
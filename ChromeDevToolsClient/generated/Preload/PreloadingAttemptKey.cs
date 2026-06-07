namespace Zu.ChromeDevTools.Preload
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// A key that identifies a preloading attempt.
    /// 
    /// The url used is the url specified by the trigger (i.e. the initial URL), and
    /// not the final url that is navigated to. For example, prerendering allows
    /// same-origin main frame navigations during the attempt, but the attempt is
    /// still keyed with the initial URL.
    /// </summary>
    public sealed class PreloadingAttemptKey
    {
        /// <summary>
        /// Gets or sets the loaderId
        /// </summary>
        [JsonPropertyName("loaderId")]
        public string LoaderId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the action
        /// </summary>
        [JsonPropertyName("action")]
        public SpeculationAction Action
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the url
        /// </summary>
        [JsonPropertyName("url")]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the formSubmission
        /// </summary>
        [JsonPropertyName("formSubmission")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? FormSubmission
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the targetHint
        /// </summary>
        [JsonPropertyName("targetHint")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public SpeculationTargetHint? TargetHint
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.Preload
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Information of headers to be displayed when the header mismatch occurred.
    /// </summary>
    public sealed class PrerenderMismatchedHeaders
    {
        /// <summary>
        /// Gets or sets the headerName
        /// </summary>
        [JsonPropertyName("headerName")]
        public string HeaderName
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the initialValue
        /// </summary>
        [JsonPropertyName("initialValue")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string InitialValue
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the activationValue
        /// </summary>
        [JsonPropertyName("activationValue")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ActivationValue
        {
            get;
            set;
        }
    }
}
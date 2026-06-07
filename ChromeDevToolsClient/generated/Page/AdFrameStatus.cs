namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Indicates whether a frame has been identified as an ad and why.
    /// </summary>
    public sealed class AdFrameStatus
    {
        /// <summary>
        /// Gets or sets the adFrameType
        /// </summary>
        [JsonPropertyName("adFrameType")]
        public AdFrameType AdFrameType
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the explanations
        /// </summary>
        [JsonPropertyName("explanations")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public AdFrameExplanation[] Explanations
        {
            get;
            set;
        }
    }
}
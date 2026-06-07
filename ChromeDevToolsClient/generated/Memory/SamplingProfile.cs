namespace Zu.ChromeDevTools.Memory
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Array of heap profile samples.
    /// </summary>
    public sealed class SamplingProfile
    {
        /// <summary>
        /// Gets or sets the samples
        /// </summary>
        [JsonPropertyName("samples")]
        public SamplingProfileNode[] Samples
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the modules
        /// </summary>
        [JsonPropertyName("modules")]
        public Module[] Modules
        {
            get;
            set;
        }
    }
}
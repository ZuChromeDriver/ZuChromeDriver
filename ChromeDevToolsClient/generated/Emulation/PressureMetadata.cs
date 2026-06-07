namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class PressureMetadata
    {
        /// <summary>
        /// Gets or sets the available
        /// </summary>
        [JsonPropertyName("available")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Available
        {
            get;
            set;
        }
    }
}
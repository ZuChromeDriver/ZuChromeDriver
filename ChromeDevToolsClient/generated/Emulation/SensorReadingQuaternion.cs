namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class SensorReadingQuaternion
    {
        /// <summary>
        /// Gets or sets the x
        /// </summary>
        [JsonPropertyName("x")]
        public double X
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the y
        /// </summary>
        [JsonPropertyName("y")]
        public double Y
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the z
        /// </summary>
        [JsonPropertyName("z")]
        public double Z
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the w
        /// </summary>
        [JsonPropertyName("w")]
        public double W
        {
            get;
            set;
        }
    }
}
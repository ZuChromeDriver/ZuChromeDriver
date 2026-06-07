namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Screen orientation.
    /// </summary>
    public sealed class ScreenOrientation
    {
        /// <summary>
        /// Orientation type.
        ///</summary>
        [JsonPropertyName("type")]
        public string Type
        {
            get;
            set;
        }
        /// <summary>
        /// Orientation angle.
        ///</summary>
        [JsonPropertyName("angle")]
        public long Angle
        {
            get;
            set;
        }
    }
}
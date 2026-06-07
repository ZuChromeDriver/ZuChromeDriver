namespace Zu.ChromeDevTools.SystemInfo
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Describes the width and height dimensions of an entity.
    /// </summary>
    public sealed class Size
    {
        /// <summary>
        /// Width in pixels.
        ///</summary>
        [JsonPropertyName("width")]
        public long Width
        {
            get;
            set;
        }
        /// <summary>
        /// Height in pixels.
        ///</summary>
        [JsonPropertyName("height")]
        public long Height
        {
            get;
            set;
        }
    }
}
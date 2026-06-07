namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Rectangle.
    /// </summary>
    public sealed class Rect
    {
        /// <summary>
        /// X coordinate
        ///</summary>
        [JsonPropertyName("x")]
        public double X
        {
            get;
            set;
        }
        /// <summary>
        /// Y coordinate
        ///</summary>
        [JsonPropertyName("y")]
        public double Y
        {
            get;
            set;
        }
        /// <summary>
        /// Rectangle width
        ///</summary>
        [JsonPropertyName("width")]
        public double Width
        {
            get;
            set;
        }
        /// <summary>
        /// Rectangle height
        ///</summary>
        [JsonPropertyName("height")]
        public double Height
        {
            get;
            set;
        }
    }
}
namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Box model.
    /// </summary>
    public sealed class BoxModel
    {
        /// <summary>
        /// Content box
        ///</summary>
        [JsonPropertyName("content")]
        public double[] Content
        {
            get;
            set;
        }
        /// <summary>
        /// Padding box
        ///</summary>
        [JsonPropertyName("padding")]
        public double[] Padding
        {
            get;
            set;
        }
        /// <summary>
        /// Border box
        ///</summary>
        [JsonPropertyName("border")]
        public double[] Border
        {
            get;
            set;
        }
        /// <summary>
        /// Margin box
        ///</summary>
        [JsonPropertyName("margin")]
        public double[] Margin
        {
            get;
            set;
        }
        /// <summary>
        /// Node width
        ///</summary>
        [JsonPropertyName("width")]
        public long Width
        {
            get;
            set;
        }
        /// <summary>
        /// Node height
        ///</summary>
        [JsonPropertyName("height")]
        public long Height
        {
            get;
            set;
        }
        /// <summary>
        /// Shape outside coordinates
        ///</summary>
        [JsonPropertyName("shapeOutside")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ShapeOutsideInfo ShapeOutside
        {
            get;
            set;
        }
    }
}
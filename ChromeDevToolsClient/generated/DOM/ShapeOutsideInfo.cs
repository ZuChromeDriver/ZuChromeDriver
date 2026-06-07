namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// CSS Shape Outside details.
    /// </summary>
    public sealed class ShapeOutsideInfo
    {
        /// <summary>
        /// Shape bounds
        ///</summary>
        [JsonPropertyName("bounds")]
        public double[] Bounds
        {
            get;
            set;
        }
        /// <summary>
        /// Shape coordinate details
        ///</summary>
        [JsonPropertyName("shape")]
        public object[] Shape
        {
            get;
            set;
        }
        /// <summary>
        /// Margin shape bounds
        ///</summary>
        [JsonPropertyName("marginShape")]
        public object[] MarginShape
        {
            get;
            set;
        }
    }
}
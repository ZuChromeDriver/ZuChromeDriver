namespace Zu.ChromeDevTools.LayerTree
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Serialized fragment of layer picture along with its offset within the layer.
    /// </summary>
    public sealed class PictureTile
    {
        /// <summary>
        /// Offset from owning layer left boundary
        ///</summary>
        [JsonPropertyName("x")]
        public double X
        {
            get;
            set;
        }
        /// <summary>
        /// Offset from owning layer top boundary
        ///</summary>
        [JsonPropertyName("y")]
        public double Y
        {
            get;
            set;
        }
        /// <summary>
        /// Base64-encoded snapshot data. (Encoded as a base64 string when passed over JSON)
        ///</summary>
        [JsonPropertyName("picture")]
        public string Picture
        {
            get;
            set;
        }
    }
}
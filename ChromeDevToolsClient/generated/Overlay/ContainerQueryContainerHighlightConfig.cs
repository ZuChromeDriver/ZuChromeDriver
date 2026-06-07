namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class ContainerQueryContainerHighlightConfig
    {
        /// <summary>
        /// The style of the container border.
        ///</summary>
        [JsonPropertyName("containerBorder")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public LineStyle ContainerBorder
        {
            get;
            set;
        }
        /// <summary>
        /// The style of the descendants' borders.
        ///</summary>
        [JsonPropertyName("descendantBorder")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public LineStyle DescendantBorder
        {
            get;
            set;
        }
    }
}
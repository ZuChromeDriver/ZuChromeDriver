namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class ComputedStyleExtraFields
    {
        /// <summary>
        /// Returns whether or not this node is being rendered with base appearance,
        /// which happens when it has its appearance property set to base/base-select
        /// or it is in the subtree of an element being rendered with base appearance.
        ///</summary>
        [JsonPropertyName("isAppearanceBase")]
        public bool IsAppearanceBase
        {
            get;
            set;
        }
    }
}
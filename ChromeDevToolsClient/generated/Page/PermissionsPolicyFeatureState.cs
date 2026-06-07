namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class PermissionsPolicyFeatureState
    {
        /// <summary>
        /// Gets or sets the feature
        /// </summary>
        [JsonPropertyName("feature")]
        public PermissionsPolicyFeature Feature
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the allowed
        /// </summary>
        [JsonPropertyName("allowed")]
        public bool Allowed
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the locator
        /// </summary>
        [JsonPropertyName("locator")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public PermissionsPolicyBlockLocator Locator
        {
            get;
            set;
        }
    }
}
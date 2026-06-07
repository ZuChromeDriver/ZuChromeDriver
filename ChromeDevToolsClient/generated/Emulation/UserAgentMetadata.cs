namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Used to specify User Agent Client Hints to emulate. See https://wicg.github.io/ua-client-hints
    /// Missing optional values will be filled in by the target with what it would normally use.
    /// </summary>
    public sealed class UserAgentMetadata
    {
        /// <summary>
        /// Brands appearing in Sec-CH-UA.
        ///</summary>
        [JsonPropertyName("brands")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public UserAgentBrandVersion[] Brands
        {
            get;
            set;
        }
        /// <summary>
        /// Brands appearing in Sec-CH-UA-Full-Version-List.
        ///</summary>
        [JsonPropertyName("fullVersionList")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public UserAgentBrandVersion[] FullVersionList
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the fullVersion
        /// </summary>
        [JsonPropertyName("fullVersion")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string FullVersion
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the platform
        /// </summary>
        [JsonPropertyName("platform")]
        public string Platform
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the platformVersion
        /// </summary>
        [JsonPropertyName("platformVersion")]
        public string PlatformVersion
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the architecture
        /// </summary>
        [JsonPropertyName("architecture")]
        public string Architecture
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the model
        /// </summary>
        [JsonPropertyName("model")]
        public string Model
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the mobile
        /// </summary>
        [JsonPropertyName("mobile")]
        public bool Mobile
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the bitness
        /// </summary>
        [JsonPropertyName("bitness")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Bitness
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the wow64
        /// </summary>
        [JsonPropertyName("wow64")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Wow64
        {
            get;
            set;
        }
        /// <summary>
        /// Used to specify User Agent form-factor values.
        /// See https://wicg.github.io/ua-client-hints/#sec-ch-ua-form-factors
        ///</summary>
        [JsonPropertyName("formFactors")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string[] FormFactors
        {
            get;
            set;
        }
    }
}
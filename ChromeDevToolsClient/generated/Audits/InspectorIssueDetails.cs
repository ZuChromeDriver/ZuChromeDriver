namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// This struct holds a list of optional fields with additional information
    /// specific to the kind of issue. When adding a new issue code, please also
    /// add a new optional field to this type.
    /// </summary>
    public sealed class InspectorIssueDetails
    {
        /// <summary>
        /// Gets or sets the cookieIssueDetails
        /// </summary>
        [JsonPropertyName("cookieIssueDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CookieIssueDetails CookieIssueDetails
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the mixedContentIssueDetails
        /// </summary>
        [JsonPropertyName("mixedContentIssueDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public MixedContentIssueDetails MixedContentIssueDetails
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the blockedByResponseIssueDetails
        /// </summary>
        [JsonPropertyName("blockedByResponseIssueDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public BlockedByResponseIssueDetails BlockedByResponseIssueDetails
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the heavyAdIssueDetails
        /// </summary>
        [JsonPropertyName("heavyAdIssueDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public HeavyAdIssueDetails HeavyAdIssueDetails
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the contentSecurityPolicyIssueDetails
        /// </summary>
        [JsonPropertyName("contentSecurityPolicyIssueDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ContentSecurityPolicyIssueDetails ContentSecurityPolicyIssueDetails
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the sharedArrayBufferIssueDetails
        /// </summary>
        [JsonPropertyName("sharedArrayBufferIssueDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public SharedArrayBufferIssueDetails SharedArrayBufferIssueDetails
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the corsIssueDetails
        /// </summary>
        [JsonPropertyName("corsIssueDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CorsIssueDetails CorsIssueDetails
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the attributionReportingIssueDetails
        /// </summary>
        [JsonPropertyName("attributionReportingIssueDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public AttributionReportingIssueDetails AttributionReportingIssueDetails
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the quirksModeIssueDetails
        /// </summary>
        [JsonPropertyName("quirksModeIssueDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public QuirksModeIssueDetails QuirksModeIssueDetails
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the partitioningBlobURLIssueDetails
        /// </summary>
        [JsonPropertyName("partitioningBlobURLIssueDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public PartitioningBlobURLIssueDetails PartitioningBlobURLIssueDetails
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the navigatorUserAgentIssueDetails
        /// </summary>
        [JsonPropertyName("navigatorUserAgentIssueDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public NavigatorUserAgentIssueDetails NavigatorUserAgentIssueDetails
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the genericIssueDetails
        /// </summary>
        [JsonPropertyName("genericIssueDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public GenericIssueDetails GenericIssueDetails
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the deprecationIssueDetails
        /// </summary>
        [JsonPropertyName("deprecationIssueDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DeprecationIssueDetails DeprecationIssueDetails
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the clientHintIssueDetails
        /// </summary>
        [JsonPropertyName("clientHintIssueDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ClientHintIssueDetails ClientHintIssueDetails
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the federatedAuthRequestIssueDetails
        /// </summary>
        [JsonPropertyName("federatedAuthRequestIssueDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public FederatedAuthRequestIssueDetails FederatedAuthRequestIssueDetails
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the bounceTrackingIssueDetails
        /// </summary>
        [JsonPropertyName("bounceTrackingIssueDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public BounceTrackingIssueDetails BounceTrackingIssueDetails
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the cookieDeprecationMetadataIssueDetails
        /// </summary>
        [JsonPropertyName("cookieDeprecationMetadataIssueDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CookieDeprecationMetadataIssueDetails CookieDeprecationMetadataIssueDetails
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the stylesheetLoadingIssueDetails
        /// </summary>
        [JsonPropertyName("stylesheetLoadingIssueDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public StylesheetLoadingIssueDetails StylesheetLoadingIssueDetails
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the propertyRuleIssueDetails
        /// </summary>
        [JsonPropertyName("propertyRuleIssueDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public PropertyRuleIssueDetails PropertyRuleIssueDetails
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the federatedAuthUserInfoRequestIssueDetails
        /// </summary>
        [JsonPropertyName("federatedAuthUserInfoRequestIssueDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public FederatedAuthUserInfoRequestIssueDetails FederatedAuthUserInfoRequestIssueDetails
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the sharedDictionaryIssueDetails
        /// </summary>
        [JsonPropertyName("sharedDictionaryIssueDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public SharedDictionaryIssueDetails SharedDictionaryIssueDetails
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the elementAccessibilityIssueDetails
        /// </summary>
        [JsonPropertyName("elementAccessibilityIssueDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ElementAccessibilityIssueDetails ElementAccessibilityIssueDetails
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the sriMessageSignatureIssueDetails
        /// </summary>
        [JsonPropertyName("sriMessageSignatureIssueDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public SRIMessageSignatureIssueDetails SriMessageSignatureIssueDetails
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the unencodedDigestIssueDetails
        /// </summary>
        [JsonPropertyName("unencodedDigestIssueDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public UnencodedDigestIssueDetails UnencodedDigestIssueDetails
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the connectionAllowlistIssueDetails
        /// </summary>
        [JsonPropertyName("connectionAllowlistIssueDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ConnectionAllowlistIssueDetails ConnectionAllowlistIssueDetails
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the userReidentificationIssueDetails
        /// </summary>
        [JsonPropertyName("userReidentificationIssueDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public UserReidentificationIssueDetails UserReidentificationIssueDetails
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the permissionElementIssueDetails
        /// </summary>
        [JsonPropertyName("permissionElementIssueDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public PermissionElementIssueDetails PermissionElementIssueDetails
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the performanceIssueDetails
        /// </summary>
        [JsonPropertyName("performanceIssueDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public PerformanceIssueDetails PerformanceIssueDetails
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the selectivePermissionsInterventionIssueDetails
        /// </summary>
        [JsonPropertyName("selectivePermissionsInterventionIssueDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public SelectivePermissionsInterventionIssueDetails SelectivePermissionsInterventionIssueDetails
        {
            get;
            set;
        }
    }
}
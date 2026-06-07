namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GenericIssueErrorType
    {
        [JsonStringEnumMemberName("FormLabelForNameError")]
        FormLabelForNameError,
        [JsonStringEnumMemberName("FormDuplicateIdForInputError")]
        FormDuplicateIdForInputError,
        [JsonStringEnumMemberName("FormInputWithNoLabelError")]
        FormInputWithNoLabelError,
        [JsonStringEnumMemberName("FormAutocompleteAttributeEmptyError")]
        FormAutocompleteAttributeEmptyError,
        [JsonStringEnumMemberName("FormEmptyIdAndNameAttributesForInputError")]
        FormEmptyIdAndNameAttributesForInputError,
        [JsonStringEnumMemberName("FormAriaLabelledByToNonExistingIdError")]
        FormAriaLabelledByToNonExistingIdError,
        [JsonStringEnumMemberName("FormInputAssignedAutocompleteValueToIdOrNameAttributeError")]
        FormInputAssignedAutocompleteValueToIdOrNameAttributeError,
        [JsonStringEnumMemberName("FormLabelHasNeitherForNorNestedInputError")]
        FormLabelHasNeitherForNorNestedInputError,
        [JsonStringEnumMemberName("FormLabelForMatchesNonExistingIdError")]
        FormLabelForMatchesNonExistingIdError,
        [JsonStringEnumMemberName("FormInputHasWrongButWellIntendedAutocompleteValueError")]
        FormInputHasWrongButWellIntendedAutocompleteValueError,
        [JsonStringEnumMemberName("ResponseWasBlockedByORB")]
        ResponseWasBlockedByORB,
        [JsonStringEnumMemberName("NavigationEntryMarkedSkippable")]
        NavigationEntryMarkedSkippable,
        [JsonStringEnumMemberName("BackUINavigationWouldSkipAd")]
        BackUINavigationWouldSkipAd,
        [JsonStringEnumMemberName("AutofillAndManualTextPolicyControlledFeaturesInfo")]
        AutofillAndManualTextPolicyControlledFeaturesInfo,
        [JsonStringEnumMemberName("AutofillPolicyControlledFeatureInfo")]
        AutofillPolicyControlledFeatureInfo,
        [JsonStringEnumMemberName("ManualTextPolicyControlledFeatureInfo")]
        ManualTextPolicyControlledFeatureInfo,
        [JsonStringEnumMemberName("FormModelContextParameterMissingTitleAndDescription")]
        FormModelContextParameterMissingTitleAndDescription,
        [JsonStringEnumMemberName("FormModelContextMissingToolName")]
        FormModelContextMissingToolName,
        [JsonStringEnumMemberName("FormModelContextMissingToolDescription")]
        FormModelContextMissingToolDescription,
        [JsonStringEnumMemberName("FormModelContextRequiredParameterMissingName")]
        FormModelContextRequiredParameterMissingName,
        [JsonStringEnumMemberName("FormModelContextParameterMissingName")]
        FormModelContextParameterMissingName,
    }
}
namespace Zu.ChromeDevTools.Accessibility
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Values of AXProperty name:
    /// - from 'busy' to 'roledescription': states which apply to every AX node
    /// - from 'live' to 'root': attributes which apply to nodes in live regions
    /// - from 'autocomplete' to 'valuetext': attributes which apply to widgets
    /// - from 'checked' to 'selected': states which apply to widgets
    /// - from 'activedescendant' to 'owns': relationships between elements other than parent/child/sibling
    /// - from 'activeFullscreenElement' to 'uninteresting': reasons why this noode is hidden
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AXPropertyName
    {
        [JsonStringEnumMemberName("actions")]
        Actions,
        [JsonStringEnumMemberName("busy")]
        Busy,
        [JsonStringEnumMemberName("disabled")]
        Disabled,
        [JsonStringEnumMemberName("editable")]
        Editable,
        [JsonStringEnumMemberName("focusable")]
        Focusable,
        [JsonStringEnumMemberName("focused")]
        Focused,
        [JsonStringEnumMemberName("hidden")]
        Hidden,
        [JsonStringEnumMemberName("hiddenRoot")]
        HiddenRoot,
        [JsonStringEnumMemberName("invalid")]
        Invalid,
        [JsonStringEnumMemberName("keyshortcuts")]
        Keyshortcuts,
        [JsonStringEnumMemberName("settable")]
        Settable,
        [JsonStringEnumMemberName("roledescription")]
        Roledescription,
        [JsonStringEnumMemberName("live")]
        Live,
        [JsonStringEnumMemberName("atomic")]
        Atomic,
        [JsonStringEnumMemberName("relevant")]
        Relevant,
        [JsonStringEnumMemberName("root")]
        Root,
        [JsonStringEnumMemberName("autocomplete")]
        Autocomplete,
        [JsonStringEnumMemberName("hasPopup")]
        HasPopup,
        [JsonStringEnumMemberName("level")]
        Level,
        [JsonStringEnumMemberName("multiselectable")]
        Multiselectable,
        [JsonStringEnumMemberName("orientation")]
        Orientation,
        [JsonStringEnumMemberName("multiline")]
        Multiline,
        [JsonStringEnumMemberName("readonly")]
        Readonly,
        [JsonStringEnumMemberName("required")]
        Required,
        [JsonStringEnumMemberName("valuemin")]
        Valuemin,
        [JsonStringEnumMemberName("valuemax")]
        Valuemax,
        [JsonStringEnumMemberName("valuetext")]
        Valuetext,
        [JsonStringEnumMemberName("checked")]
        Checked,
        [JsonStringEnumMemberName("expanded")]
        Expanded,
        [JsonStringEnumMemberName("modal")]
        Modal,
        [JsonStringEnumMemberName("pressed")]
        Pressed,
        [JsonStringEnumMemberName("selected")]
        Selected,
        [JsonStringEnumMemberName("activedescendant")]
        Activedescendant,
        [JsonStringEnumMemberName("controls")]
        Controls,
        [JsonStringEnumMemberName("describedby")]
        Describedby,
        [JsonStringEnumMemberName("details")]
        Details,
        [JsonStringEnumMemberName("errormessage")]
        Errormessage,
        [JsonStringEnumMemberName("flowto")]
        Flowto,
        [JsonStringEnumMemberName("labelledby")]
        Labelledby,
        [JsonStringEnumMemberName("owns")]
        Owns,
        [JsonStringEnumMemberName("url")]
        Url,
        [JsonStringEnumMemberName("activeFullscreenElement")]
        ActiveFullscreenElement,
        [JsonStringEnumMemberName("activeModalDialog")]
        ActiveModalDialog,
        [JsonStringEnumMemberName("activeAriaModalDialog")]
        ActiveAriaModalDialog,
        [JsonStringEnumMemberName("ariaHiddenElement")]
        AriaHiddenElement,
        [JsonStringEnumMemberName("ariaHiddenSubtree")]
        AriaHiddenSubtree,
        [JsonStringEnumMemberName("emptyAlt")]
        EmptyAlt,
        [JsonStringEnumMemberName("emptyText")]
        EmptyText,
        [JsonStringEnumMemberName("inertElement")]
        InertElement,
        [JsonStringEnumMemberName("inertSubtree")]
        InertSubtree,
        [JsonStringEnumMemberName("labelContainer")]
        LabelContainer,
        [JsonStringEnumMemberName("labelFor")]
        LabelFor,
        [JsonStringEnumMemberName("notRendered")]
        NotRendered,
        [JsonStringEnumMemberName("notVisible")]
        NotVisible,
        [JsonStringEnumMemberName("presentationalRole")]
        PresentationalRole,
        [JsonStringEnumMemberName("probablyPresentational")]
        ProbablyPresentational,
        [JsonStringEnumMemberName("inactiveCarouselTabContent")]
        InactiveCarouselTabContent,
        [JsonStringEnumMemberName("uninteresting")]
        Uninteresting,
    }
}
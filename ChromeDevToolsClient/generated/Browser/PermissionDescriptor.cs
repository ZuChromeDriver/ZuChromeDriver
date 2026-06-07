namespace Zu.ChromeDevTools.Browser
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Definition of PermissionDescriptor defined in the Permissions API:
    /// https://w3c.github.io/permissions/#dom-permissiondescriptor.
    /// </summary>
    public sealed class PermissionDescriptor
    {
        /// <summary>
        /// Name of permission.
        /// See https://cs.chromium.org/chromium/src/third_party/blink/renderer/modules/permissions/permission_descriptor.idl for valid permission names.
        ///</summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// For "midi" permission, may also specify sysex control.
        ///</summary>
        [JsonPropertyName("sysex")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Sysex
        {
            get;
            set;
        }
        /// <summary>
        /// For "push" permission, may specify userVisibleOnly.
        /// Note that userVisibleOnly = true is the only currently supported type.
        ///</summary>
        [JsonPropertyName("userVisibleOnly")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? UserVisibleOnly
        {
            get;
            set;
        }
        /// <summary>
        /// For "clipboard" permission, may specify allowWithoutSanitization.
        ///</summary>
        [JsonPropertyName("allowWithoutSanitization")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? AllowWithoutSanitization
        {
            get;
            set;
        }
        /// <summary>
        /// For "fullscreen" permission, must specify allowWithoutGesture:true.
        ///</summary>
        [JsonPropertyName("allowWithoutGesture")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? AllowWithoutGesture
        {
            get;
            set;
        }
        /// <summary>
        /// For "camera" permission, may specify panTiltZoom.
        ///</summary>
        [JsonPropertyName("panTiltZoom")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? PanTiltZoom
        {
            get;
            set;
        }
    }
}
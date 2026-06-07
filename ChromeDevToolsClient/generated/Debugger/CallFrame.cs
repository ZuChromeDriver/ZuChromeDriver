namespace Zu.ChromeDevTools.Debugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// JavaScript call frame. Array of call frames form the call stack.
    /// </summary>
    public sealed class CallFrame
    {
        /// <summary>
        /// Call frame identifier. This identifier is only valid while the virtual machine is paused.
        ///</summary>
        [JsonPropertyName("callFrameId")]
        public string CallFrameId
        {
            get;
            set;
        }
        /// <summary>
        /// Name of the JavaScript function called on this call frame.
        ///</summary>
        [JsonPropertyName("functionName")]
        public string FunctionName
        {
            get;
            set;
        }
        /// <summary>
        /// Location in the source code.
        ///</summary>
        [JsonPropertyName("functionLocation")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Location FunctionLocation
        {
            get;
            set;
        }
        /// <summary>
        /// Location in the source code.
        ///</summary>
        [JsonPropertyName("location")]
        public Location Location
        {
            get;
            set;
        }
        /// <summary>
        /// JavaScript script name or url.
        /// Deprecated in favor of using the `location.scriptId` to resolve the URL via a previously
        /// sent `Debugger.scriptParsed` event.
        ///</summary>
        [JsonPropertyName("url")]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// Scope chain for this call frame.
        ///</summary>
        [JsonPropertyName("scopeChain")]
        public Scope[] ScopeChain
        {
            get;
            set;
        }
        /// <summary>
        /// `this` object for this call frame.
        ///</summary>
        [JsonPropertyName("this")]
        public Runtime.RemoteObject This
        {
            get;
            set;
        }
        /// <summary>
        /// The value being returned, if the function is at return point.
        ///</summary>
        [JsonPropertyName("returnValue")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Runtime.RemoteObject ReturnValue
        {
            get;
            set;
        }
        /// <summary>
        /// Valid only while the VM is paused and indicates whether this frame
        /// can be restarted or not. Note that a `true` value here does not
        /// guarantee that Debugger#restartFrame with this CallFrameId will be
        /// successful, but it is very likely.
        ///</summary>
        [JsonPropertyName("canBeRestarted")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? CanBeRestarted
        {
            get;
            set;
        }
    }
}
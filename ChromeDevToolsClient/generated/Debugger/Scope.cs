namespace Zu.ChromeDevTools.Debugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Scope description.
    /// </summary>
    public sealed class Scope
    {
        /// <summary>
        /// Scope type.
        ///</summary>
        [JsonPropertyName("type")]
        public string Type
        {
            get;
            set;
        }
        /// <summary>
        /// Object representing the scope. For `global` and `with` scopes it represents the actual
        /// object; for the rest of the scopes, it is artificial transient object enumerating scope
        /// variables as its properties.
        ///</summary>
        [JsonPropertyName("object")]
        public Runtime.RemoteObject Object
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Location in the source code where scope starts
        ///</summary>
        [JsonPropertyName("startLocation")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Location StartLocation
        {
            get;
            set;
        }
        /// <summary>
        /// Location in the source code where scope ends
        ///</summary>
        [JsonPropertyName("endLocation")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Location EndLocation
        {
            get;
            set;
        }
    }
}
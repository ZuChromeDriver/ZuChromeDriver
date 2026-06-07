namespace Zu.ChromeDevTools.Runtime
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns properties of a given object. Object group of the result is inherited from the target
    /// object.
    /// </summary>
    public sealed class GetPropertiesCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Runtime.getProperties";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Identifier of the object to return properties for.
        /// </summary>
        [JsonPropertyName("objectId")]
        public string ObjectId
        {
            get;
            set;
        }
        /// <summary>
        /// If true, returns properties belonging only to the element itself, not to its prototype
        /// chain.
        /// </summary>
        [JsonPropertyName("ownProperties")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? OwnProperties
        {
            get;
            set;
        }
        /// <summary>
        /// If true, returns accessor properties (with getter/setter) only; internal properties are not
        /// returned either.
        /// </summary>
        [JsonPropertyName("accessorPropertiesOnly")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? AccessorPropertiesOnly
        {
            get;
            set;
        }
        /// <summary>
        /// Whether preview should be generated for the results.
        /// </summary>
        [JsonPropertyName("generatePreview")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? GeneratePreview
        {
            get;
            set;
        }
        /// <summary>
        /// If true, returns non-indexed properties only.
        /// </summary>
        [JsonPropertyName("nonIndexedPropertiesOnly")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? NonIndexedPropertiesOnly
        {
            get;
            set;
        }
    }

    public sealed class GetPropertiesCommandResponse : ICommandResponse<GetPropertiesCommand>
    {
        /// <summary>
        /// Object properties.
        ///</summary>
        [JsonPropertyName("result")]
        public PropertyDescriptor[] Result
        {
            get;
            set;
        }
        /// <summary>
        /// Internal object properties (only of the element itself).
        ///</summary>
        [JsonPropertyName("internalProperties")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public InternalPropertyDescriptor[] InternalProperties
        {
            get;
            set;
        }
        /// <summary>
        /// Object private properties.
        ///</summary>
        [JsonPropertyName("privateProperties")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public PrivatePropertyDescriptor[] PrivateProperties
        {
            get;
            set;
        }
        /// <summary>
        /// Exception details.
        ///</summary>
        [JsonPropertyName("exceptionDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ExceptionDetails ExceptionDetails
        {
            get;
            set;
        }
    }
}
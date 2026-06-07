namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class GetLonghandPropertiesCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "CSS.getLonghandProperties";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the shorthandName
        /// </summary>
        [JsonPropertyName("shorthandName")]
        public string ShorthandName
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the value
        /// </summary>
        [JsonPropertyName("value")]
        public string Value
        {
            get;
            set;
        }
    }

    public sealed class GetLonghandPropertiesCommandResponse : ICommandResponse<GetLonghandPropertiesCommand>
    {
        /// <summary>
        /// Gets or sets the longhandProperties
        /// </summary>
        [JsonPropertyName("longhandProperties")]
        public CSSProperty[] LonghandProperties
        {
            get;
            set;
        }
    }
}
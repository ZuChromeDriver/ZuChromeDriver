namespace Zu.ChromeDevTools.Runtime
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// This method tries to lookup and populate exception details for a
    /// JavaScript Error object.
    /// Note that the stackTrace portion of the resulting exceptionDetails will
    /// only be populated if the Runtime domain was enabled at the time when the
    /// Error was thrown.
    /// </summary>
    public sealed class GetExceptionDetailsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Runtime.getExceptionDetails";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// The error object for which to resolve the exception details.
        /// </summary>
        [JsonPropertyName("errorObjectId")]
        public string ErrorObjectId
        {
            get;
            set;
        }
    }

    public sealed class GetExceptionDetailsCommandResponse : ICommandResponse<GetExceptionDetailsCommand>
    {
        /// <summary>
        /// Gets or sets the exceptionDetails
        /// </summary>
        [JsonPropertyName("exceptionDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ExceptionDetails ExceptionDetails
        {
            get;
            set;
        }
    }
}
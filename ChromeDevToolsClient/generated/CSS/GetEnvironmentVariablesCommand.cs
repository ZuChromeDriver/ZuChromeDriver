namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns the values of the default UA-defined environment variables used in env()
    /// </summary>
    public sealed class GetEnvironmentVariablesCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "CSS.getEnvironmentVariables";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class GetEnvironmentVariablesCommandResponse : ICommandResponse<GetEnvironmentVariablesCommand>
    {
        /// <summary>
        /// Gets or sets the environmentVariables
        /// </summary>
        [JsonPropertyName("environmentVariables")]
        public object EnvironmentVariables
        {
            get;
            set;
        }
    }
}
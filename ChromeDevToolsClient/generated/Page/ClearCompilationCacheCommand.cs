namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Clears seeded compilation cache.
    /// </summary>
    public sealed class ClearCompilationCacheCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.clearCompilationCache";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class ClearCompilationCacheCommandResponse : ICommandResponse<ClearCompilationCacheCommand>
    {
    }
}
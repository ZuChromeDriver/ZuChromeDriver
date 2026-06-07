namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Undoes the last performed action.
    /// </summary>
    public sealed class UndoCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOM.undo";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class UndoCommandResponse : ICommandResponse<UndoCommand>
    {
    }
}
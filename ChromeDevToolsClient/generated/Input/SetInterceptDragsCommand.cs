namespace Zu.ChromeDevTools.Input
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Prevents default drag and drop behavior and instead emits `Input.dragIntercepted` events.
    /// Drag and drop behavior can be directly controlled via `Input.dispatchDragEvent`.
    /// </summary>
    public sealed class SetInterceptDragsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Input.setInterceptDrags";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the enabled
        /// </summary>
        [JsonPropertyName("enabled")]
        public bool Enabled
        {
            get;
            set;
        }
    }

    public sealed class SetInterceptDragsCommandResponse : ICommandResponse<SetInterceptDragsCommand>
    {
    }
}
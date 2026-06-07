namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class GetAdScriptAncestryCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.getAdScriptAncestry";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the frameId
        /// </summary>
        [JsonPropertyName("frameId")]
        public string FrameId
        {
            get;
            set;
        }
    }

    public sealed class GetAdScriptAncestryCommandResponse : ICommandResponse<GetAdScriptAncestryCommand>
    {
        /// <summary>
        /// The ancestry chain of ad script identifiers leading to this frame's
        /// creation, along with the root script's filterlist rule. The ancestry
        /// chain is ordered from the most immediate script (in the frame creation
        /// stack) to more distant ancestors (that created the immediately preceding
        /// script). Only sent if frame is labelled as an ad and ids are available.
        ///</summary>
        [JsonPropertyName("adScriptAncestry")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Network.AdAncestry AdScriptAncestry
        {
            get;
            set;
        }
    }
}
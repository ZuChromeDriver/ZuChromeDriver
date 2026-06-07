namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns the styles coming from animations & transitions
    /// including the animation & transition styles coming from inheritance chain.
    /// </summary>
    public sealed class GetAnimatedStylesForNodeCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "CSS.getAnimatedStylesForNode";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the nodeId
        /// </summary>
        [JsonPropertyName("nodeId")]
        public long NodeId
        {
            get;
            set;
        }
    }

    public sealed class GetAnimatedStylesForNodeCommandResponse : ICommandResponse<GetAnimatedStylesForNodeCommand>
    {
        /// <summary>
        /// Styles coming from animations.
        ///</summary>
        [JsonPropertyName("animationStyles")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CSSAnimationStyle[] AnimationStyles
        {
            get;
            set;
        }
        /// <summary>
        /// Style coming from transitions.
        ///</summary>
        [JsonPropertyName("transitionsStyle")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CSSStyle TransitionsStyle
        {
            get;
            set;
        }
        /// <summary>
        /// Inherited style entries for animationsStyle and transitionsStyle from
        /// the inheritance chain of the element.
        ///</summary>
        [JsonPropertyName("inherited")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public InheritedAnimatedStyleEntry[] Inherited
        {
            get;
            set;
        }
    }
}
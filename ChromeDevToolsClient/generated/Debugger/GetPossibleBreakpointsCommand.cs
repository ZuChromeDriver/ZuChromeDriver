namespace Zu.ChromeDevTools.Debugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns possible locations for breakpoint. scriptId in start and end range locations should be
    /// the same.
    /// </summary>
    public sealed class GetPossibleBreakpointsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Debugger.getPossibleBreakpoints";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Start of range to search possible breakpoint locations in.
        /// </summary>
        [JsonPropertyName("start")]
        public Location Start
        {
            get;
            set;
        }
        /// <summary>
        /// End of range to search possible breakpoint locations in (excluding). When not specified, end
        /// of scripts is used as end of range.
        /// </summary>
        [JsonPropertyName("end")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Location End
        {
            get;
            set;
        }
        /// <summary>
        /// Only consider locations which are in the same (non-nested) function as start.
        /// </summary>
        [JsonPropertyName("restrictToFunction")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? RestrictToFunction
        {
            get;
            set;
        }
    }

    public sealed class GetPossibleBreakpointsCommandResponse : ICommandResponse<GetPossibleBreakpointsCommand>
    {
        /// <summary>
        /// List of the possible breakpoint locations.
        ///</summary>
        [JsonPropertyName("locations")]
        public BreakLocation[] Locations
        {
            get;
            set;
        }
    }
}